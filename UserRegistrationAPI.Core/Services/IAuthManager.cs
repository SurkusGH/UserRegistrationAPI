using System.Threading.Tasks;
using UserRegistrationAPI.Core.DTOs;

namespace UserRegistrationAPI.Core.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();
    }
}
