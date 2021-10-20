using Common.Models.Users;

namespace BussinesLayer.Interfaces
{
    public interface IAuthService
    {
        string BuildToken(User userName);
    }
}
