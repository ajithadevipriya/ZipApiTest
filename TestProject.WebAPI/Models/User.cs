using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public Guid UniqueId { get;}
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal MonthlyExpense { get; set; }
    }
}
