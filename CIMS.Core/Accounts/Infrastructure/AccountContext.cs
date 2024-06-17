using CIMS.Core.Accounts.Domain;
using CIMS.Core.Common.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Core.Accounts.Infrastructure
{
    [RegisterService(ServiceLifetime.Scoped)]
    public class AccountContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CIMS;Trusted_Connection=True;ConnectRetryCount=0"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Account").HasKey("Id");

            base.OnModelCreating(modelBuilder);
        }
    }
}
