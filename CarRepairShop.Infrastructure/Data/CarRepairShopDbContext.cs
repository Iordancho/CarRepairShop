﻿using CarRepairShop.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRepairShop.Infrastructure.Data
{
    public class CarRepairShopDbContext : IdentityDbContext
    {
        public CarRepairShopDbContext(DbContextOptions<CarRepairShopDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Reservation>()
                .HasOne(r => r.RepairShop)
                .WithMany(r => r.Reservations)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<RepairShop> RepairShops { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
    }
}