using Microsoft.EntityFrameworkCore;
using RPGame.Context;
using RPGame.Model;
using RPGame.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IPlayer, PlayerImplement>();


var connection = builder.Configuration["ConnectionStrings:Connections"];
builder.Services.AddDbContext<RPGameSQLiteContext>(option => option.UseSqlite(connection));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
