using System;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Repository
{
    public static class UserRepository
    {
        private static string _connectionString => "ConnectionString";
        public static User GetUserByEmailAddress(string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
                throw new ArgumentNullException(nameof(emailAddress));

            const string sql = @"
                select 
                    *
                from dbo.User with (nolock)
                    where EmailAddress = @EmailAddress";
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<User>(sql, new { EmailAddress = emailAddress }).FirstOrDefault();
            }
        }

        public static User GetUserById(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException(nameof(userId));

            const string sql = @"
                select 
                    *
                from dbo.User with (nolock)
                    where UniqueId = @UserId";
            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<User>(sql, new { UserId = userId }).FirstOrDefault();
            }
        }

        public static IEnumerable<User> GetAllUser()
        {

            const string sql = @"
                select 
                    u.*
                from dbo.User u with (nolock)";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<User>(sql);
            }
        }

        public static void SaveUser(User user)
        {
            const string sql = @"                               
                insert into dbo.User (
                    UniqueId,
                    Name,
                    EmailAddress,
                    MonthlySalary,
                    MonthlyExpense
                )
                select
                    newid(),
                    @Name,
                    @EmailAddress,
                    @MonthlySalary,
                    @MonthlyExpense
                    ";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute(sql, new { Name = user.Name, EmailAddress = user.EmailAddress, MonthlySalary = user.MonthlySalary, MonthlyExpense = user.MonthlyExpense });
            }
        }
    }
}
