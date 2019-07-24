using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankDetails.Models
{
    public class BankDetailsDbContext : DbContext
    {
        public BankDetailsDbContext(DbContextOptions<BankDetailsDbContext> options)
        : base(options)
        {
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Branch> Branches { get; set; }

    }
}
