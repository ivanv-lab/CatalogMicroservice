
using CatalogMicroservice.Mappings;
using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Implements;
using CatalogMicroservice.Repositories.Interfaces;
using CatalogMicroservice.Services.Implements;
using CatalogMicroservice.Services.Interfaces;

namespace CatalogMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();
            builder.Services.AddScoped<CatalogDbContext>();

            builder.Services.AddTransient<IProductPropertyValueRepository,
                ProductPropertyValueRepository>();
            builder.Services.AddTransient<IProductPropertyRepository,
                ProductPropertyRepository>();
            builder.Services.AddTransient<IProductCategoryRepository,
                ProductCategoryRepository>();
            builder.Services.AddTransient<IProductRepository,
                ProductRepository>();

            builder.Services.AddTransient<IProductPropertyValueService,
                ProductPropertyValueService>();
            builder.Services.AddTransient<IProductPropertyService,
                ProductPropertyService>();
            builder.Services.AddTransient<IProductCategoryService,
                ProductCategoryService>();
            builder.Services.AddTransient<IProductService,
                ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.Run();
        }
    }
}
