using HPlusSport.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ShopContext>(options =>
        {
            options.UseInMemoryDatabase("Shop");
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ShopContext>();
            await db.Database.EnsureCreatedAsync();
        }

        app.MapGet("/products", async (ShopContext _shopContext) =>
        {
            return await _shopContext.Products.ToListAsync();
        });

        app.MapGet("/products/{id}", async (int id, ShopContext _shopContext) =>
        {
            var product = await _shopContext.Products.FindAsync(id);

            if (product == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product);
        }).WithName("GetProduct");

        app.MapPost("/product", async (Product product, ShopContext _shopContext) =>

        {
            _shopContext.Products.Add(product);
            await _shopContext.SaveChangesAsync();
            return Results.CreatedAtRoute("GetProduct", new { id = product.Id, product });


            app.MapPut("/product/{id}", async (int id, [FromBody] Product product, ShopContext _shopContext) =>
            {
                _shopContext.Entry(product).State = EntityState.Modified;
                try
                {
                    await _shopContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!_shopContext.Products.Any(p => p.Id == id))
                    {
                        return Results.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return Results.NoContent();
            });


            app.MapDelete("/product/{id}", async (int id, ShopContext _shopContext) =>
            {
                var product = await _shopContext.Products.FindAsync(id);
                if (product == null)
                {
                    return Results.NotFound();
                }
            });

                       app.Run();
    }
}