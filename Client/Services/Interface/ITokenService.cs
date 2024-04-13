using IdentityModel.Client;

namespace Client.Services.Interface
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
