// EncuestaApp.API/Program.cs
using Microsoft.EntityFrameworkCore;
using Data;
using Business.Contracts;
using Domain;
using Business.Implementation;
using Data.Contracts;
using Data.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SurveyDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddScoped<IEncuestaService, EncuestaService>();
builder.Services.AddScoped<IEncuestaRepository, EncuestaRepository>();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();