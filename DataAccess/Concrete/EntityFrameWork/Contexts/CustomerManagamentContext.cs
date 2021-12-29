using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork.Contexts
{
    public class CustomerManagamentContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=HUSOKA\SQLEXPRESS01; Database=CustomerManagement; Trusted_Connection=true");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<StarbucksCustomer> StarbucksCustomers { get; set; }
        public DbSet<PortalCustomer> PortalCustomers { get; set; }
    }
}
