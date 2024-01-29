using BetUp.DbContexts;
using BetUp.DbModels;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//main context
builder.Services.AddDbContext<BetUpContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("BetUpDb")));

//repositories
builder.Services.AddScoped<IBaseRepository<Role>, BaseRepository<Role>>();
//add Cors
builder.Services.AddCors(options => options.AddPolicy(name: "FrontendUI", policy =>
{
    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//use cors
app.UseCors("FrontendUI");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
