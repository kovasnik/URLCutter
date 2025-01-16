using Microsoft.AspNetCore.Mvc;
using URLCutter.BLL.Interfaces;
using URLCutter.DTO;

namespace URLCutter.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            var response = new LoginDTO();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid) return View(loginDTO);

            try
            {
                var isLoginSuccessful = await _accountService.LoginAsync(loginDTO);

                if (!isLoginSuccessful)
                {
                    ViewBag.Error = "Password or email is incorrect";
                    return View(loginDTO);
                }
            }
            catch (InvalidOperationException)
            {
                ViewBag.Error = "Something went wrong. Please try again later.";
                return View(loginDTO);
            }


            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp()
        {
            var response = new RegisterDTO();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid) return View(registerDTO);

            try
            {
                var registerResult = await _accountService.RegisterAsync(registerDTO);
                if (!registerResult.Succeeded)
                {
                    ViewBag.Error = "Registration failed. Please check your data.";
                    return View(registerDTO);
                }

            }
            catch (ArgumentException ex)
            {
                ViewBag.Error = ex.Message;
            }
            catch (InvalidOperationException)
            {
                ViewBag.Error = "Something went wrong. Please try again later.";
                return View(registerDTO);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
