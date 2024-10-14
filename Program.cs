
using CatalogMicroservice.Mappings;
using CatalogMicroservice.Models;
using CatalogMicroservice.Repositories.Implements;
using CatalogMicroservice.Repositories.Interfaces;
using CatalogMicroservice.Services.Implements;
using CatalogMicroservice.Services.Interfaces;
using CatalogMicroservice.Utils;
using System.Reflection;

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
            builder.Services.AddSwaggerGen(options =>
            {
                var xmlFilename =
                $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext
                    .BaseDirectory, xmlFilename));
            });
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

            builder.Services.AddScoped<ProductPropertyValueMapper>();
            builder.Services.AddScoped<ProductPropertyMapper>();
            builder.Services.AddScoped<ProductCategoryMapper>();
            builder.Services.AddScoped<ProductMapper>();

            builder.Services.AddTransient<IProductPropertyValueService,
                ProductPropertyValueService>();
            builder.Services.AddTransient<IProductPropertyService,
                ProductPropertyService>();
            builder.Services.AddTransient<IProductCategoryService,
                ProductCategoryService>();
            builder.Services.AddTransient<IProductService,
                ProductService>();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:5205");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });

            var app = builder.Build();

            using var scope=app.Services.CreateScope();
            using var dbContext = scope.ServiceProvider
                .GetRequiredService<CatalogDbContext>();
            dbContext.Database.EnsureCreatedAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseCors();
            app.UseAuthorization();
            app.Run();
        }
    }
}
