using Domain;
using Domain.Data;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class IdentityUserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public IdentityUserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task Login(LoginVM viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, true, false);

            if (!result.Succeeded)
            {
                throw new Exception("Wrong username or password!");
            }
        }


        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}