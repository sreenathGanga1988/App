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
        public POSDataContext() : base("LIMSDB")
        {
            Database.SetInitializer<POSDataContext>(null);
            //  Database.SetInitializer(new DropCreateDatabaseAlways<POSDataContext>());
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<User> MyProperty { get; set; }
    }
}
