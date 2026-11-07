using Application.Products;
using Infrastructure.Persistence;
using Infrastructure.Products;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.UseNetTopologySuite()));

builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

const string customerAppCorsPolicy = "CustomerApp";
builder.Services.AddCors(options =>
{
    options.AddPolicy(customerAppCorsPolicy, policy =>
        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(customerAppCorsPolicy);

app.MapControllers();

app.Run();
