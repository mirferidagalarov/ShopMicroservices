using Microsoft.EntityFrameworkCore;
using Shop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Persistence.Context
{
    public class OrderContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;Initial Catalog=ShopOrderDb;User=SA;Password=123456789aA!");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }    
        public DbSet<Ordering> Orderings { get; set; }  
    }
}
