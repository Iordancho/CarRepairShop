using CarRepairShop.Infrastructure.Data.Models;
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

            builder.Entity<RepairShop>()
                .HasData(new RepairShop()
                {
                    Id = 1,
                    Address = "23 G.S. Rakovski Street, Sofia",
                    OwnerId = "a3d9b176-7ae8-4451-b3f9-6990b0677407",
                    ImageUrl = "https://t4.ftcdn.net/jpg/05/32/90/47/360_F_532904710_cl1gmPtUVGwtiYk10cQlmdQPqaFIlmuD.jpg"
                },
                new RepairShop()
                {
                    Id = 2,
                    Address = "37 Vasil Levski Street, Plovdiv",
                    OwnerId = "a3d9b176-7ae8-4451-b3f9-6990b0677407",
                    ImageUrl = "https://media.istockphoto.com/id/147255060/photo/automobiles-serum-station.jpg?s=612x612&w=0&k=20&c=svpKwYykZuAqpg8Pn_qBQBfLLA1d21vTl2Tswr9DZQs="
                },
                new RepairShop()
                {
                    Id = 3,
                    Address = "82 Khan Krum Street, Burgas",
                    OwnerId = "a3d9b176-7ae8-4451-b3f9-6990b0677407",
                    ImageUrl = "https://pictures.dealer.com/l/lithiamotors11/1802/c99cb8a036699f3bcd5cd434df53c93cx.jpg?impolicy=downsize&w=568"
                });


            base.OnModelCreating(builder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<RepairShop> RepairShops { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
    }
}
