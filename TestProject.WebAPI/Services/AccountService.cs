using System;
using System.Collections.Generic;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.Repository;

namespace TestProject.WebAPI.Services
{
    public static class AccountService
    {
        public static string CreateAccount(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException(nameof(userId));

            var user = UserService.GetUser(userId);
            if (user == null)
                throw new Exception($"User not found for given Id {userId}");

            if ((user.MonthlySalary - user.MonthlyExpense) > 1000)
            {
                AccountRepository.CreateAccount(user.Id);
                return "Successfully created an account.";
            }
            else
            {
                return $"Cannot create an account for the given user {user.Name} as (monthly salary - monthly expenses) is less than $1000.";
            }
        }

        public static IEnumerable<Account> GetAllAccounts()
        {
            return AccountRepository.GetAllAccounts();
        }
    }
}
