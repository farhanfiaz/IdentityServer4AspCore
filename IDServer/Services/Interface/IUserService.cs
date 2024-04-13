using IdentityServer4.Test;

namespace IDServer.Services.Interface
{
    public interface IUserService
    {
        public List<TestUser> GetUserList();
    }
}
