﻿using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.Settings;
using eniyisinerede.webui.ViewModels.Auth;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using SharedLibrary.Dtos;
using System.Globalization;
using System.Security.Claims;
using System.Text.Json;

namespace eniyisinerede.webui.Services;

public class IdentityService : IIdentityService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor; //Cookie'ye erişim için
    private readonly ClientSettings _clientSettings;
    private readonly ServiceSettings _serviceApiSettings;


    public IdentityService(HttpClient httpClient, 
        IHttpContextAccessor httpContextAccessor,
        IOptions<ClientSettings> clientSettings,
        IOptions<ServiceSettings> serviceApiSettings)
    {
        _httpClient = httpClient;
        _httpContextAccessor = httpContextAccessor;
        _clientSettings = clientSettings.Value;
        _serviceApiSettings = serviceApiSettings.Value;
    }

    public async Task<TokenResponse> GetAccessTokenByRefreshToken()
    {

        var discovery= await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address=_serviceApiSettings.IdentityBaseUri,
            Policy= new DiscoveryPolicy{RequireHttps=false }
        });

        if (discovery.IsError)
        {
            throw discovery.Exception;
        }
        var refreshToken= await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken); //Cookie'denn refresh token alıyoruz.

        RefreshTokenRequest refreshTokenRequest= new()
        {
            ClientId=_clientSettings.WebClient.ClientId,
            ClientSecret=_clientSettings.WebClient.ClientSecret,
            RefreshToken=refreshToken,
            Address=discovery.TokenEndpoint
        };
        var token=await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);
        if (token.IsError)
        {
            return null;
        }
        var authenticationTokens=new List<AuthenticationToken> {
            new AuthenticationToken{
                Name=OpenIdConnectParameterNames.AccessToken,
                Value=token.AccessToken },
             new AuthenticationToken{
                Name=OpenIdConnectParameterNames.RefreshToken,
                Value=token.RefreshToken },
              new AuthenticationToken{
                Name=OpenIdConnectParameterNames.ExpiresIn,
                Value=DateTime.Now.AddSeconds(token.ExpiresIn).ToString("O",CultureInfo.InvariantCulture) }
        };
        var authenticationResult=await _httpContextAccessor.HttpContext.AuthenticateAsync();
        var properties=authenticationResult.Properties;
        properties.StoreTokens(authenticationTokens);
        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            authenticationResult.Principal, properties);
        return token;
    }


    public async Task RevokeRefreshToken() //Kullanıcı çıkış yaptığında token'ın silinmesi
    {
        var discovery= await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address=_serviceApiSettings.IdentityBaseUri,
            Policy= new DiscoveryPolicy{RequireHttps=false }
        });
        if (discovery.IsError)
        {
            throw discovery.Exception;
        }
        var refreshToken=await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
        TokenRevocationRequest tokenRevocationRequest=new TokenRevocationRequest
        {
            ClientId=_clientSettings.WebClientForUser.ClientId, //User olmayanında üyelik sistemi olmadığı için bu kısımlar olmaz.
            ClientSecret=_clientSettings.WebClientForUser.ClientSecret,
            Address=discovery.RevocationEndpoint,
            Token=refreshToken,
            TokenTypeHint="refresh_token"
        //Bu kısımlar IdentityModel sitesinden öğrenilebilir. 
        };
        await _httpClient.RevokeTokenAsync(tokenRevocationRequest);

    }

    public async Task<ApiResponse<bool>> SignInAsync(SignInInputModel signInInputModel)
    {
        var discovery= await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address= _serviceApiSettings.IdentityBaseUri,
            Policy=new DiscoveryPolicy{RequireHttps=true}
        });//IdentiyModel'den client için yazılmış. Default olarak https'e istek yapar.

        if (discovery.IsError)
            throw discovery.Exception;

        PasswordTokenRequest passwordTokenRequest= new PasswordTokenRequest
        {
            ClientId= _clientSettings.WebClientForUser.ClientId,
            ClientSecret=_clientSettings.WebClientForUser.ClientSecret,
            UserName= signInInputModel.Username,
            Password= signInInputModel.Password,
            Address=discovery.TokenEndpoint
        }; //Resource Owner Grant Type'a göre ayarlandı.
        var token= await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

        if (token.IsError)
        {
            var responseContent= await token.HttpResponse.Content.ReadAsStringAsync();
            var errorDto= JsonSerializer.Deserialize<ErrorDto>(responseContent,new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive=true //Case sensitive iptal
            });
            return ApiResponse<bool>.Fail(errorDto.Errors, 400);
        }
    
        //Token içerisinde rol,email ve öteki bilgileri userinfo endpointine atacağımız req'den gelsin ki elimizdeki token'ı şişirmeyelim.
        
        UserInfoRequest userInfoRequest= new UserInfoRequest
        {
            Token = token.AccessToken,  
            Address = discovery.UserInfoEndpoint
        };
        
        var userInfo=await _httpClient.GetUserInfoAsync(userInfoRequest);
        
        
        if (userInfo.IsError)
            throw userInfo.Exception;


        //Elimizde userInfo var.Cookie'ye ekleyelim ki claim bazlı yetkilendirme yapabilelim.
        ClaimsIdentity claimsIdentity= new(userInfo.Claims,
            CookieAuthenticationDefaults.AuthenticationScheme,
            "name","role"
            ); //Sadece tek bir üyelik sistemimiz olduğu için AuthenticationScheme ile geçtik.
        //Herhangi bir yerde kullanıcının username'ini almak istediğimizde HttpContext.User.Identity.Name üzerinden alıyoruz.Bu değeri almak için cookie'den hangi değeri okuyacağımızı "name" keywordu ile belirledik.Bu zaten identityserver4.readthedocs.io'da endpoints/userInfo example'ında mevcut
        //Requestten gelen rolleri de role keyword'unden okuyacağız.
        ClaimsPrincipal claimsPrincipal=new(claimsIdentity);

        var authenticationProperties= new AuthenticationProperties(); //Accesstoken ve refresh token'ı cookie de tutacağız.

        authenticationProperties.StoreTokens(new List<AuthenticationToken> {
            new AuthenticationToken{
                Name=OpenIdConnectParameterNames.AccessToken,
                Value=token.AccessToken },
             new AuthenticationToken{
                Name=OpenIdConnectParameterNames.RefreshToken,
                Value=token.RefreshToken },
              new AuthenticationToken{
                Name=OpenIdConnectParameterNames.ExpiresIn,
                Value=DateTime.Now.AddSeconds(token.ExpiresIn).ToString("O",CultureInfo.InvariantCulture) }
        }); //Buradaki name value'leri sabitlerden alalım OpenidConnect

        //oAuth2.0 yetkilendirmeyle ilgili bir protokoldür
        //OpenIdConnect ise authentication ile ilgilidir.
        //Eğer kullanıcının login olması için IdentityServer'a yönlendirecek olsaydık:
        //Microsoft.AspNetCore.Authentication.OpenIdConnect package'a ihtiyacımız olacaktı.
        //Microsoft.IdentityModel.Protocols.OpenIdConnect paketini projemize dahil ettik.

        authenticationProperties.IsPersistent = signInInputModel.RememberMe;

        await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

        return ApiResponse<bool>.Success(200);
    }

    public async Task<ApiResponse<bool>> SignUpAsync(SignUpInputModel signUpInputModel)
    {
        var requestResponse = await _httpClient.PostAsJsonAsync("api/auth", signUpInputModel);
        if (!requestResponse.IsSuccessStatusCode)
            return ApiResponse<bool>.Fail("İstek server'a iletilemedi.",(int)requestResponse.StatusCode);

        return ApiResponse<bool>.Success(201);
    }
}
