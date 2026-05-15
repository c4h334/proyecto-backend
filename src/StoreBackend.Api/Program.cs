using Microsoft.EntityFrameworkCore;
using StoreBackend.DomainService;
using StoreBackend.Facade;
using StoreBackend.Infraestructure.Repositories;
using StoreBackend.Infrastructure;
using StoreBackend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOriginsPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins!)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")

)

);

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Services
builder.Services.AddScoped<IProductService, ProductService>();

// Facades
builder.Services.AddScoped<IProductFacade, ProductFacade>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Repositories
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

// Services
builder.Services.AddScoped<ISupplierService, SupplierService>();

// Facades
builder.Services.AddScoped<ISupplierFacade, SupplierFacade>();

// Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Services
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Facades
builder.Services.AddScoped<ICustomerFacade, CustomerFacade>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowedOriginsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
