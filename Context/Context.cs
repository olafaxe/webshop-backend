
using System;
using Microsoft.EntityFrameworkCore;
using shopApi.Models;

namespace shopApi.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)

         => options.UseSqlite("Data Source = mydb.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Sak",
                Image = "https://picsum.photos/id/204/5184/3456",
                Info = "En sak. Standard",
                Price = 50.00,

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Annan sak",
                Image = "https://picsum.photos/id/19/2500/1667",
                Info = "Likadan som den andra saken fast en annan.",
                Price = 30.00,

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Kanske en sak",
                Image = "https://picsum.photos/id/144/4912/2760",
                Info = "Troligtvis en sak men också lite oklart.",
                Price = 10.00,

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Lite fula saker",
                Image = "https://picsum.photos/id/164/1200/800",
                Info = "Hög med saker. Inte så fina.",
                Price = 1005.00,

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Fin sak",
                Image = "https://picsum.photos/id/131/4698/3166",
                Info = "En väldigt fin sak. Och billig.",
                Price = 5.00,

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Två udda saker",
                Image = "https://picsum.photos/id/154/3264/2176",
                Info = "Två udda saker. Precis som namnet beskriver.",
                Price = 99.00,

            });

            // Orderitems
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 1,
                ProductId = 2,
                OrderId = 1
            });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 2,
                ProductId = 2,
                OrderId = 1
            });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 3,
                ProductId = 3,
                OrderId = 1
            });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 4,
                ProductId = 1,
                OrderId = 2
            });
            modelBuilder.Entity<OrderItem>().HasData(new OrderItem
            {
                Id = 5,
                ProductId = 3,
                OrderId = 3
            });

            //Orders
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                OrderDate = DateTime.Now.AddDays(-25),
                CustomerId = 3,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 2,
                OrderDate = DateTime.Now.AddDays(-5),
                CustomerId = 2,
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 3,
                OrderDate = DateTime.Now.AddDays(-6),
                CustomerId = 1,
            });


            //Customers
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                UserName = "Ola",
                Email = "ola@mail.com"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 2,
                UserName = "Anton",
                Email = "anton@mail.com"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 3,
                UserName = "Faxe",
                Email = "faxe@mail.com"
            });

        }


    }
}