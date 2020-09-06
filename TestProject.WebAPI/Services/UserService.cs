using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.Repository;

namespace TestProject.WebAPI.Services
{
    public class UserService
    {
        public static void CreateUser(User newUser)
        {
            if (newUser == null)
                throw new Exception("Inavlid user.");

            ValidateUser(newUser);

            if (DoesUserExists(newUser.EmailAddress))
                throw new Exception($"Cannot create already existing user for the given email address {newUser.EmailAddress}");

            UserRepository.SaveUser(newUser);
        }

        public static User GetUser(Guid userId)
        {
            return UserRepository.GetUserById(userId);
        }

        public static IEnumerable<User> GetAllUsers()
        {
            return UserRepository.GetAllUser();
        }

        private static bool DoesUserExists(string emailAddress)
        {
            var user = UserRepository.GetUserByEmailAddress(emailAddress);
            return user != null;
        }

        private static void ValidateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.EmailAddress.Trim()) || !MailAddressService.IsValid(user.EmailAddress.Trim()))
                throw new Exception("Inavlid Email Address");

            if (user.MonthlyExpense < 0 || user.MonthlySalary < 0)
                throw new Exception("Invalid monthly expense or salary");
        }

    }
}
