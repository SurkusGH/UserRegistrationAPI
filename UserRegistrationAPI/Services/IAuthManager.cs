using System.Threading.Tasks;
using UserRegistrationAPI.Models;

namespace UserRegistrationAPI.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
    }
}
