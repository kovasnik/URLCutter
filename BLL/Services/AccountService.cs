using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using URLCutter.BLL.Interfaces;
using URLCutter.DTO;
using URLCutter.Models;

namespace URLCutter.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null) return false;

            var passwordChek = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!passwordChek) return false;

            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = await _userManager.FindByEmailAsync(registerDTO.Email);
            if (user != null) throw new ArgumentException("User with this email already exists");

            var newUser = new User()
            {
                Email = registerDTO.Email,
                UserName = registerDTO.UserName,
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerDTO.Password);
            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "User");
            }

            return newUserResponse;
        }
    }
}
