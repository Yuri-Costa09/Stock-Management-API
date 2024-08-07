using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockManagementAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StockManagementDbContext>(options =>
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
