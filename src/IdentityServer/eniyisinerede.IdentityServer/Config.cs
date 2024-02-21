// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace eniyisinerede.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName),

            new ApiResource("product_resource"){Scopes={"product_fullpermission"}},
            new ApiResource("place_resource"){Scopes={"place_fullpermission"}},

            new ApiResource("location_resource"){Scopes={"location_fullpermission"}},
            new ApiResource("reservation_resource"){Scopes={"reservation_fullpermission","reservation_readpermission","reservation_writepermission"}},

            new ApiResource("fileapi_resource"){Scopes={"fileapi_fullpermission"}},
            new ApiResource("gateway_resource"){Scopes={"gateway_fullpermission"}},


        }; // audience'lara karşılık gelecek.
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                        new IdentityResources.OpenId(),//kullanıcının id email ve password gönderildiğinde jwt almak istiyorsak mutlaka token içerisinde(jwt payloadında) subject keyword'ünün dolu olması gerekir.OpenId mutlaka olmalı OpenIdConnect Protocol'ünün zorunlu kıldığı alandır
                        new IdentityResources.Profile(),//kullanıcı profil bilgileri address vs
                        new IdentityResources.Email(),
                        new IdentityResource(){ Name="roles",DisplayName="Roles" ,Description="Kullanıcı rolleri",UserClaims=new[]{ "role"} } //Kendi claim'imizi oluşturuyoruz yukarıdakiler hazır claimler
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName), 
                //Identity Server'ın kendisine istek yapabilmek için IdentityServer'ın kendi sabitidir.
                //IdentityServer'ı da versek kabul eder.
                new ApiScope("product_fullpermission","Product API'a erişim için full yetki."),
                new ApiScope("place_fullpermission","Product API'a erişim için full yetki."),

                new ApiScope("location_fullpermission","Location API'a erişim için full yetki verdik."),

                new ApiScope("reservation_fullpermission","Reservation API'a erişim için full yetki verdik."),
                new ApiScope("reservation_readpermission","Reservation API'a erişim için okuma yetkisi verdik."),
                new ApiScope("reservation_writepermission","Reservation API'a erişim için yazma yetkisi verdik."),

                new ApiScope("fileapi_fullpermission","File API'a erişim için full yetki verdik."),
                new ApiScope("gateway_fullpermission","Gateway'e erişim için full yetki verdik."),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                { 
                    ClientName="Asp.Net Core MVC",
                    ClientId="WebMvcClient",
                    ClientSecrets={new Secret("Secret-1234".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials, //Refresh token barındırmayan GrantType'dır.
                    AllowedScopes={ "product_fullpermission",
                        "place_fullpermission",
                        "location_fullpermission",
                        "gateway_fullpermission",
                        IdentityServerConstants.LocalApi.ScopeName //Bu scope'da belirlediğimiz clientId ve Secret ile hangi api'lara istek yapılabileceğini burada belirtiyoruz.
                    },
                    AccessTokenLifetime=30*24*60*60, //30 gün
                    RefreshTokenUsage=TokenUsage.OneTimeOnly
                },
                new Client()
                {
                    ClientName="Asp.Net Core MVC",
                    ClientId="WebMvcClientForUser",
                    ClientSecrets={new Secret("Secret-1234".Sha256())},
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword, //ResourceOwnerPasswordAndClientCredentials kullanırsak refresh token kullanamayız.
                    AllowOfflineAccess=true, //**** OfflineAccess Kullanıcı offline olsa bile kullanıcı adına bir refresh token göndererek kullanıcı için yeni bir accesstoken almamıza olanak verir.
                    AllowedScopes={ 
                        "fileapi_fullpermission",
                        "gateway_fullpermission",
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.LocalApi.ScopeName, //API'ın kendisine istek yapabilmek için
                        IdentityServerConstants.StandardScopes.OfflineAccess,//Refresh token dönebilmemiz için OfflineAccess'de ekledik.
                        "roles",
                        "reservation_fullpermission",
                        "reservation_readpermission",
                        "reservation_writepermission"
                    },
                    AccessTokenLifetime=60*60, //1 Saat
                    RefreshTokenUsage=TokenUsage.ReUse,
                    RefreshTokenExpiration=TokenExpiration.Absolute, 
                    //Refresh token'ın süresi dolduğunda süreyi uzatacak mıyız ayarıdır.Yaptığımız ayar sabite denk gelir.
                    AbsoluteRefreshTokenLifetime=(int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds, //60 gün
                   // ! Her accesstoken alımında yeni bir refresh token da alınacaktır!.
                },


                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "scope1" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope2" }
                },
            };
    }
}