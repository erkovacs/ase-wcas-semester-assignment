using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BikeStore.Models;
using System;
using System.Linq;

namespace BikeStore.Data
{
    public static class SeedData
    {

        private static void SeedCategories(ApplicationDbContext context)
        {
            // Look for any products.
            if (context.Categories.Any())
            {
                return;   // DB has already been seeded
            }

            context.Categories.AddRange(
                new Category
                {
                    Name = "XC",
                    Description = "Cross-country riding: lightweight frames (between 7 and 16 kg) with front suspension forks optimised for relatively flat but bumpy terrain"
                },
                new Category
                {
                    Name = "Trail",
                    Description = "Trail riding: bikes with more aggressive geometry and longer fork travel (100-140mm) optimised for short, steep descents"
                },
                new Category
                {
                    Name = "AM",
                    Description = "All-mountain riding: full-suspension bikes with over 120mm of travel optimised for heavier downhills but suitable for climbs too"
                },
                new Category
                {
                    Name = "Dirt jump",
                    Description = "Dirt jumping: simple, tough and light bikes with front suspension forks used for dirt jumping and other acrobatics"
                },
                new Category
                {
                    Name = "DH",
                    Description = "Downhill riding: tough, long-travel full-suspension bikes for long, aggressive and technical descents"
                },
                new Category
                {
                    Name = "Accessories",
                    Description = "Bike accesories"
                }
            );

            context.SaveChanges();
        }
        private static void SeedProducts(ApplicationDbContext context)
        {
            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            context.Products.AddRange(
                new Product
                {
                    Name = "Cross XC Bike 29''",
                    Description = "Entry level XC Bike",
                    CategoryFK = 1,
                    Price = 500.0m
                },
                new Product
                {
                    Name = "Merida Trail Bike",
                    Description = "Intermediate trail bike with excellent fork",
                    CategoryFK = 2,
                    Price = 900.0m
                },
                new Product
                {
                    Name = "Bike seat",
                    Description = "Seat for a bike",
                    CategoryFK = 6,
                    Price = 35.0m
                },
                new Product
                {
                    Name = "Bike light",
                    Description = "Bike light for nocturnal or city riding",
                    CategoryFK = 6,
                    Price = 50.0m
                },
                new Product
                {
                    Name = "Ghost all-mountain bike 27.5''",
                    Description = "Advanced AM Bike with 140mm of travel",
                    CategoryFK = 3,
                    Price = 2500.0m
                },
                new Product
                {
                    Name = "UMF Dirt bike",
                    Description = "Tough and relatively cheap dirt jump bike",
                    CategoryFK = 4,
                    Price = 735.0m
                },
                new Product
                {
                    Name = "Bike chain",
                    Description = "Transmits power from the crankcase to the rear wheel",
                    CategoryFK = 6,
                    Price = 25.0m
                },
                new Product
                {
                    Name = "Specialized DH Bike 29''",
                    Description = "The best DH bike there is",
                    CategoryFK = 5,
                    Price = 5500m
                }
            );

            context.SaveChanges();
        }

        public static void Initialize(IServiceProvider serviceProvider)
		{
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                SeedCategories(context);
                SeedProducts(context);
            }
		}
	}
}
