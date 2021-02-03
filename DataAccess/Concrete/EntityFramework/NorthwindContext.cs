using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: db ile proje classlarını iliskilendirme
    public class NorthwindContext:DbContext
    {
        // asagidaki method hangi db ile iliskili proje
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Server=(localdb)\MSSQLLocalDB; Database=Northwind; Trusted_Connection=true");
        }

        //hangi tabloya hangi class karsilik geliyor
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
