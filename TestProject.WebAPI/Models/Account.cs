using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Models
{
    public class Account
    {
        public int AccountNumber { get; set; } // Use  ID Identity (10000, 1) Primary key not null in DB
        public int AccountName { get; set; }
        public int UserId { get; set; }
    }
}
