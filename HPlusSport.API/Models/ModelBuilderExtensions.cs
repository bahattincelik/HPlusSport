using Microsoft.EntityFrameworkCore;


namespace HPlusSport.API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Active Wear - Men" },
                new Category { Id = 2, Name = "Active Wear - Women" },
                new Category { Id = 3, Name = "Minarel Water" },
                new Category { Id = 4, Name = "Publications" },
                new Category { Id = 5, Name = "Supplements" });


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true,},
                new Product { Id = 2, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 3, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 4, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 5, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 6, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 7, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 8, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 9, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 10, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 11, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 12, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 13, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true },
                new Product { Id = 14, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "ASDFG", Price = 25, IsAvailable = true });


        }
    }
}
