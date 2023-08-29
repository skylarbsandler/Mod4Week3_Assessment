using CommerceMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CommerceMvc.DataAccess
{
    public class CommerceMvcContext : DbContext
    {
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Product> Products { get; set; }

        public CommerceMvcContext(DbContextOptions<CommerceMvcContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Merchant>().HasData(
                new Merchant { Id = 1, Name = "Biker Jim's", Category = "Restaurant" },
                new Merchant { Id = 2, Name = "REI", Category = "Outdoor" },
                new Merchant { Id = 3, Name = "Walter's 303", Category = "Restaurant" }
            );

            Random rand = new Random();

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, MerchantId = 1, Name = "Elk Jalapeno Cheddar", Description = "A yummy hotdog", Category = "Food", StockQuantity = rand.Next(100), ReleaseDate = DateTimeOffset.Now.AddDays(-(rand.Next(365)))  },
                new Product { Id = 2, MerchantId = 1, Name = "Chicken Peach Chipotle", Description = "A pretty yummy hotdog", Category = "Food", StockQuantity = rand.Next(100), ReleaseDate = DateTimeOffset.Now.AddDays(-(rand.Next(365)))  },
                new Product { Id = 3, MerchantId = 1, Name = "Vegan Dog", Description = "A hotdog", Category = "Food", StockQuantity = rand.Next(100), ReleaseDate = DateTimeOffset.Now.AddDays(-(rand.Next(365))) },
                new Product { Id = 4, MerchantId = 2, Name = "Teva Slip-ons", Description = "Comfy shoes", Category = "Shoes", StockQuantity = rand.Next(100), ReleaseDate = DateTimeOffset.Now.AddDays(-(rand.Next(365))) },
                new Product { Id = 5, MerchantId = 2, Name = "Waterproof Matches", Description = "Rain heaters", Category = "Camping", StockQuantity = rand.Next(100), ReleaseDate = DateTimeOffset.Now.AddDays(-(rand.Next(365))) },
                new Product { Id = 6, MerchantId = 2, Name = "Nano Puff Jacket", Description = "Great wearable blanket", Category = "Apparel", StockQuantity = rand.Next(100), ReleaseDate = DateTimeOffset.Now.AddDays(-(rand.Next(365))) },
                new Product { Id = 7, MerchantId = 3, Name = "Cheesy Breadsticks", Description = "Not a hotdog", Category = "Food", StockQuantity = rand.Next(100), ReleaseDate = DateTimeOffset.Now.AddDays(-(rand.Next(365))) },
                new Product { Id = 8, MerchantId = 3, Name = "Cheese Cake", Description = "Definitely not a hotdog", Category = "Food", StockQuantity = rand.Next(100), ReleaseDate = DateTimeOffset.Now.AddDays(-(rand.Next(365))) }
            );
        }
    }
}
