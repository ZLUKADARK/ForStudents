using Microsoft.EntityFrameworkCore;
using Test.BLL.Interfaces;
using Test.BLL.Services;
using Test.DLL.Data;
using Test.DLL.Interfaces;
using Test.DLL.Repositories;
using Test.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddTransient<IPersonServices, PersonServices>();
builder.Services.AddTransient<IAddressServices, AddressServices>();
builder.Services.AddTransient<ISocialClassServices, SocialClassServices>();

builder.Services.AddScoped<IRepository<Address>, AddressRepository>();
builder.Services.AddScoped<IRepository<Person>, PersonRepository>();
builder.Services.AddScoped<IRepository<SocialClass>, SocialClassRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Подключаем контекст БД
var connection = builder.Configuration.GetSection("DB").Value;
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connection));

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
