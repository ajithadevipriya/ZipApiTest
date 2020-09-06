using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.SeedData
{
    public static class UserDataInitializer
    {
        public static void SeedData(UserManager<User> userManager)
        {
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("devi@localhost").Result == null)
            {
                User user = new User();
                user.Name = "devi@localhost";
                user.EmailAddress = "devi@localhost";
                user.MonthlyExpense = 100;
                user.MonthlySalary = 1000;

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

        }

     }
}
