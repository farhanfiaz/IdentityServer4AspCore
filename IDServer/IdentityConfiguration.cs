using IdentityServer4.Models;
using IdentityServer4.Test;
using IDServer.Services;
using IDServer.Services.Interface;

namespace IDServer
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers()
        {
            IUserService userService = new UserService();

            return userService.GetUserList();
        }

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
                new ApiScope("myApi.delete")
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("myApi")
                {
                    Scopes = new List<string>{ "myApi.read","myApi.write","myApi.delete" },
                    ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
                }
            };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "client1",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.read" }
                },
                new Client
                {
                    ClientId = "client2",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = { new Secret("secret2".Sha256()) },
                    AllowedScopes = { "myApi.write","myApi.read","myApi.delete" }
                }
            };
    }
}
