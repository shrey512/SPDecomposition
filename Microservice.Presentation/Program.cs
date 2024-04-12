using Microservice.Application.Interfaces;
using Microservice.Infra.Data;
using Microservice.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microservice.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISampleService, SampleService>();
builder.Services.AddScoped<IMicroserviceRepo, MicroserviceRepo>();


builder.Services.AddControllers();

builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//db
builder.Services.AddDbContext<MicroserviceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RateDBConnection")));

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
