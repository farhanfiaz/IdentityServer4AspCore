using IdentityModel;
using IdentityServer4.Test;
using IDServer.Services.Interface;
using System.Security.Claims;

namespace IDServer.Services
{
    public class UserService : IUserService
    {
        public List<TestUser> GetUserList()
        {
            return new List<TestUser>()
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "farhan",
                    Password = "fiaz",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Farhan Fiaz"),
                        new Claim(JwtClaimTypes.GivenName, "Farhan"),
                        new Claim(JwtClaimTypes.FamilyName, "Lakhwera"),
                        new Claim(JwtClaimTypes.WebSite, "http://codewithmukesh.com"),
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "ahmad",
                    Password = "saab",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Ahmad Bhai"),
                        new Claim(JwtClaimTypes.GivenName, "Ahmad"),
                        new Claim(JwtClaimTypes.FamilyName, "abc"),
                        new Claim(JwtClaimTypes.WebSite, "http://codewithmukesh.com"),
                    }
                },
            };
        }
    }
}
