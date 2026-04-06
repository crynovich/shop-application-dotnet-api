using Microsoft.EntityFrameworkCore;
using ProductsApplication.Data;
using ProductsApplication.Features.Products.Persistence;
using ProductsApplication.Features.Suppliers.Persistence;
using ProductsApplication.Features.Categories.Persistence;
using ProductsApplication.Features.Features.Persistence;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure EF Core to use PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductsDbContext>(options => options.UseNpgsql(connectionString));

// MediatR (use-case handlers)
builder.Services.AddMediatR(typeof(Program));

// Register repositories (feature-specific)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
