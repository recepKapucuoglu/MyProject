using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{    //   Context: DATABASE tabloları ile proje classlarını bağlamak.
    public class NorthwindContext :DbContext  //DbContext: Entityframeworkun kendi base clası ,contextin ta kendisi.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                               //sql veritabanı ismi        ;databasedeki table ismi ;giriş şekli(parolasız.)
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true"); 
        }


        //veritabanındaki nesnelerimle kendi neslenerimi bağladım.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
