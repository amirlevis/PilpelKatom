global using PilpelKatom.Models;
global using PilpelKatom.Dtos.SuperHero;
global using PilpelKatom.Dtos.Character;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using PilpelKatom.Services.CharacterService;
global using PilpelKatom.Services.SuperHeroService;
using PilpelKatom;
using PilpelKatom.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddDbContext<DataContext>();
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