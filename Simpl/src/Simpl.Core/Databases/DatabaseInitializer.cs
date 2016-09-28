using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using System.Linq;
using Simpl.Core.Models;

namespace Simpl.Core.Databases
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly SimplDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public DatabaseInitializer(SimplDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await _context.Database.EnsureCreatedAsync();

            // Add Mvc.Client to the known applications.
            if (_context.Applications.Any())
            {
                foreach (var application in _context.Applications)
                    _context.Remove(application);
                _context.SaveChanges();
            }

            // no need to register an Application in this example
            //_context.Applications.Add(new Application
            //{
            //    Id = "openiddict-test",
            //    DisplayName = "My test application",
            //    RedirectUri = "http://localhost:58292/signin-oidc",
            //    LogoutRedirectUri = "http://localhost:58292/",
            //    Secret = Crypto.HashPassword("secret_secret_secret"),
            //    Type = OpenIddictConstants.ApplicationTypes.Public
            //});
            //_context.SaveChanges();

            if (_context.Users.Any())
            {
                foreach (var u in _context.Users)
                    _context.Remove(u);
                _context.SaveChanges();
            }

            var email = "user@test.com";
            User user;
            if (await _userManager.FindByEmailAsync(email) == null)
            {
                // use the create rather than addorupdate so can set password
                user = new User
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(user, "P2ssw0rd!");
            }

            user = await _userManager.FindByEmailAsync(email);
            var roleName = "admin";
            if (await _roleManager.FindByNameAsync(roleName) == null)
            {
                await _roleManager.CreateAsync(new Role() { Name = roleName });
            }

            if (!await _userManager.IsInRoleAsync(user, roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }
    }

    public interface IDatabaseInitializer
    {
        Task Seed();
    }
}
