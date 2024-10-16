using DBService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBService.Models
{
    public class OrderService
    {
        public void EnsurePopulated()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Products.Any())
                {
                    db.Products.AddRange(new Product { Name="Milk",CreatedAt=DateTime.Now,Price=60}, new Product { Name = "Apple", CreatedAt = DateTime.Now, Price = 620 },new Product { Name = "Bread", CreatedAt = DateTime.Now, Price = 14 });
                    db.SaveChanges();
                }
            }
        }

        public Product GetProduct(int id)
        {
            using (ApplicationContext db = new ApplicationContext()) {
                return db.Products.FirstOrDefault(e => e.Id == id);
            }
        }

        public void AddOrder(Order order)
        {
            using (ApplicationContext db = new ApplicationContext()) { 
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }

        public Order GetOrder(int id)
        {
            using (ApplicationContext db = new ApplicationContext()) {
                return db.Orders.Include(e => e.OrderLines).ThenInclude(e => e.Product).FirstOrDefault(e => e.Id == id);
            }
        }
    }
}
