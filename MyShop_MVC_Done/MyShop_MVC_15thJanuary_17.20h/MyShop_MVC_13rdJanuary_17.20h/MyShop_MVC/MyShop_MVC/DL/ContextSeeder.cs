using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DL
{
    public class ContextSeeder : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context con)
        {
            //User u1 = new User()
            //{
            //    Email = "dayanmend1223333333333@gmail.com",
            //    Password = "dayan",
            //    PasswordSalt = "222"
            //};

            List<Product> plist = new List<Product>()
            {
                new Product{ID = 1, Name = "Adidas T-shirts", Price = 60},
                new Product{ID = 2, Name = "Rowing boat", Price = 1500},
                new Product{ID = 3, Name = "Soccer ball", Price = 45},
                new Product{ID = 4, Name = "Nike shoes", Price = 85},
                new Product{ID = 5, Name = "Baseball bat", Price = 120},
                new Product{ID = 6, Name = "Tennis racket", Price = 150},
                new Product{ID = 7, Name = "Shoes", Price = 100},
                new Product{ID = 8, Name = "Jacket", Price = 250},
                new Product{ID = 9, Name = "Trousers", Price = 340},
                new Product{ID = 10, Name = "Belts", Price = 35},
                new Product{ID = 11, Name = "T-Shirts", Price = 180},
                new Product{ID = 12, Name = "Sweater", Price = 250},
                new Product{ID = 13, Name = "Belts", Price = 80},
                new Product{ID = 14, Name = "Shoes", Price = 150},
                new Product{ID = 15, Name = "Cotton Dress", Price = 345},
                new Product{ID = 16, Name = "Designer Clothes", Price = 185},
                new Product{ID = 17, Name = "Watches", Price = 600},
                new Product{ID = 18, Name = "Headbands", Price = 50},
                new Product{ID = 19, Name = "Headband", Price = 30},
                new Product{ID = 20, Name = "Dress", Price = 100},
                new Product{ID = 21, Name = "T-Shirts", Price = 120}
                //new Product{ID = 22, Name = "Tennis racket", Price = 150},
                //new Product{ID = 23, Name = "Tennis racket", Price = 150},
                //new Product{ID = 24, Name = "Tennis racket", Price = 150},
                //new Product{ID = 25, Name = "Tennis racket", Price = 150},
                //new Product{ID = 26, Name = "Tennis racket", Price = 150},
                //new Product{ID = 27, Name = "Tennis racket", Price = 150},
                //new Product{ID = 28, Name = "Tennis racket", Price = 150},
                //new Product{ID = 29, Name = "Tennis racket", Price = 150},
                //new Product{ID = 30, Name = "Tennis racket", Price = 150},
                //new Product{ID = 31, Name = "Tennis racket", Price = 150},
                //new Product{ID = 32, Name = "Tennis racket", Price = 150},
                //new Product{ID = 33, Name = "Tennis racket", Price = 150},
                //new Product{ID = 34, Name = "Tennis racket", Price = 150},
                //new Product{ID = 35, Name = "Tennis racket", Price = 150},
                //new Product{ID = 36, Name = "Tennis racket", Price = 150},
                //new Product{ID = 37, Name = "Tennis racket", Price = 150},
                //new Product{ID = 38, Name = "Tennis racket", Price = 150},
                //new Product{ID = 39, Name = "Tennis racket", Price = 150},

            };
            foreach (var i in plist)
            {
                con.Products.Add(i);
            }            
            con.SaveChanges();
            base.Seed(con);
        }
    }
}
