using Microsoft.AspNetCore.Identity;
using URLCutter.DTO;

namespace URLCutter.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(LoginDTO loginDTO);
        Task<IdentityResult> RegisterAsync(RegisterDTO registerDTO);
        Task LogoutAsync();
    }
}
