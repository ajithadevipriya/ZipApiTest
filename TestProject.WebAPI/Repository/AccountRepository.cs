using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Repository
{
    public static class AccountRepository
    {
        private static string _connectionString => "ConnectionString";
        public static void CreateAccount(int userId)
        {
            const string sql = @"                               
                insert into dbo.Account (
                    UniqueId,
                    AccountName,
                    UserId
                )
                select
                    newid(),
                    @AccountName,
                    @UserId
                    ";

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Execute(sql, new { AccountName = "Test Account Name", UserId = userId });
            }
        }

        public static IEnumerable<Account> GetAllAccounts()
        {
            const string sql = @"                               
                select
                    Id as 'AccountNumber',
                    AccountName
                from Account
                    ";

            using (var conn = new SqlConnection(_connectionString))
            {
                return conn.Query<Account>(sql);
            }
        }
    }
}

