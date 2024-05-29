using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uber.Infrastructure.Data.Models;

namespace Uber.Infrastructure.Data
{
    public static class AppRoleInitializer
    {
        public static void Initialize(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            SeedRoles(roleManager);
            SeedAdmin(userManager);
        }

        // fill the database with the roles in the application
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            // Add the Admin the role
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                roleManager.CreateAsync(new IdentityRole()
                {
                    Name = "Admin"
                }).Wait();
            }

            // Add the Client the role
            if (roleManager.FindByNameAsync("Client").Result == null)
            {
                roleManager.CreateAsync(new IdentityRole()
                {
                    Name = "Client"
                }).Wait();
            }

            // Add the Driver the role
            if (roleManager.FindByNameAsync("Driver").Result == null)
            {
                roleManager.CreateAsync(new IdentityRole()
                {
                    Name = "Driver"
                }).Wait();
            }
        }

        // fill the database with an initial user with Admin role
        private static void SeedAdmin(UserManager<IdentityUser> userManager)
        {
            if(userManager.FindByEmailAsync("admin1@abv.bg").Result == null)
            {
                IdentityUser adminUser = new IdentityUser()
                {
                    UserName = "admin1@test.bg",
                    Email = "admin1@test.bg",
                    EmailConfirmed = true,
                };

                IdentityResult result = userManager.CreateAsync(adminUser, "admin1pass").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                }
            }
        }
    }
}
