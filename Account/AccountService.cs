using ASP_pl.Persistance;
using ASP_pl.Persistance.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly AppDbContext _dbContext;

        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public UserRoles GetUserRoles(string userName)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserName == userName);
            var userRoles = _dbContext.UserRoles.Where(x => x.UserId == user.Id);
            var roles = _dbContext.Roles.Where(r => userRoles.Any(ur => ur.RoleId == r.Id)).Select(r => r.Name).AsEnumerable();
            return roles.Aggregate((UserRoles)0, (acc, r) => acc | (UserRoles)Enum.Parse(typeof(UserRoles), r));
        }
    }
}
