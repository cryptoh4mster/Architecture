using System;
using System.Collections.Generic;
using System.Text;
using DeliveryDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryDAL.EF
{
    public class DeliveryContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DeliveryContext(DbContextOptions<DeliveryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasData(
                new Order
                {
                    Id = 1,
                    Name = "Первая запись"
                });
        }
    }
}
    