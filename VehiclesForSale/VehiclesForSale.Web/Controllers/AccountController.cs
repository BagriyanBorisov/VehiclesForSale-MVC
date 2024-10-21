using System.Security.Claims;

namespace VehiclesForSale.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using VehiclesForSale.Core.Contracts.Chat;
    using VehiclesForSale.Data.Models;
    using ViewModels.Account;


    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        private IChatService chatService;

        public AccountController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager, IChatService chat)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            chatService = chat;
        }

        

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await userManager.GetUserAsync(User);


            var model = new ProfileViewModel();
            model.Profile.PhoneNumber = user?.PhoneNumber!;
            model.Profile.Email = user.Email;
            model.Profile.UserName = user.UserName;
            model.Notifications = await chatService.GetNotifications(user.Id);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult UpdatePassword()
        {
            var viewModel = new UpdatePasswordViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);

            if (result.Succeeded)
            {
                // Password updated successfully
                return RedirectToAction("Profile"); // Redirect to the user's profile page
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UpdateInformation()
        {
            var user = await userManager.GetUserAsync(User);
            var model = new UpdateInformationViewModel()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateInformation(UpdateInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound();
                }

                // Verify the user's password
                var passwordCheck = await userManager.CheckPasswordAsync(user, model.Password);
                if (!passwordCheck)
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password");
                    return View(model); // Show the profile view with error message
                }

                // Update user information
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Profile"); // Redirect to profile after successful update
                }

                // If update fails, add errors to model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View("Profile", model); // Show the profile view with validation errors
        }


        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                RegistrationDate = DateTime.UtcNow
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);

        }


        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await signInManager
                    .PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid Login!");

            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
