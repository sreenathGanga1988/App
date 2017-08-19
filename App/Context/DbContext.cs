using App.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Context
{
    public class POSDataContext : DbContext
    {
        public POSDataContext() : base("name = LimsDBConnectionString")
        {
           Database.SetInitializer<POSDataContext>(null);
           //  Database.SetInitializer(new DropCreateDatabaseAlways<POSDataContext>());
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ControlDiemension> ControlDiemensions { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
    }
}
