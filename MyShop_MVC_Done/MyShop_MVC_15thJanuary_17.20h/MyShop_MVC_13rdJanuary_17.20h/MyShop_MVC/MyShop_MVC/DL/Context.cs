using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DL
{
    public class Context : DbContext
    {
        public Context()
            : base("Context")
        {
            Database.SetInitializer(new ContextSeeder());
            //Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}
