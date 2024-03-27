namespace eniyisinerede.webui.Services.Interfaces;

public interface IClientCredentialTokenService
{
    Task<string> GetToken();
}
