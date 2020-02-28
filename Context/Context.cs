
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
        public DbSet<Color> Colors { get; set; }

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

            //Colors
            modelBuilder.Entity<Color>().HasData(new Color
            {
                Id = 1,
                ColorName = "Yellow",
            });

            modelBuilder.Entity<Color>().HasData(new Color
            {
                Id = 2,
                ColorName = "Pink",
            });

            modelBuilder.Entity<Color>().HasData(new Color
            {
                Id = 3,
                ColorName = "Black",
            });

            modelBuilder.Entity<Color>().HasData(new Color
            {
                Id = 4,
                ColorName = "White",
            });

        }


    }
}