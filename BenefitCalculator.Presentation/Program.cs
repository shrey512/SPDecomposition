using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RateCalculator.Application.Interfaces;
using RateCalculator.Infrastructure.Data;
using RateCalculator.Application.Services;
using RateCalculator.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//db
builder.Services.AddDbContext<RateCalcDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RateDBConnection")));

// Add services to the container.
builder.Services.AddScoped<IAgeService, AgeService>();
builder.Services.AddScoped<IBenefitService, BenefitService>();
builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//test conn string
//var connectionString = "Server=(localdb)\\mssqllocaldb;Database=RateDB;Integrated Security=true;";
//try
//{
//    using (var connection = new SqlConnection(connectionString))
//    {
//        connection.Open();
//        Console.WriteLine("Connection successful.");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Failed to connect. Error: {ex.Message}");
//}


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
