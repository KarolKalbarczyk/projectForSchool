using ASP_pl.Account;
using ASP_pl.Persistance;
using ASP_pl.Persistance.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Account
{
    public class AccountController : AppController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AccountController(
                    UserManager<User> userManager,
                    SignInManager<User> signInManager,
                    RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel model) => await Try(async () =>
         {
             var user = new User { UserName = model.Login, SecurityStamp = Guid.NewGuid().ToString() };
             var userRegistration = await _userManager.CreateAsync(user, password: model.Password);
             if (userRegistration.Succeeded)
             {
                 await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());
                 return AppJson(true);
             }
             else
                 return AppJson(false, errors: userRegistration.Errors.Select(x => x.Description));
         });

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Login(UserModel model) => await Try(async () =>
        {
            var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, true, false);
            return Redirect("~/");
        });

        [HttpGet]
        public IActionResult Login() => View();
    }
}
