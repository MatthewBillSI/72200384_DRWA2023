using Microsoft.EntityFrameworkCore;
using UTS_DRWA.Models;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoContextjadwal>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoContextjadwal") ?? throw new InvalidOperationException("Connection string 'TodoContextjadwal' not found.")));
builder.Services.AddDbContext<TodoContextmapel>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoContextmapel") ?? throw new InvalidOperationException("Connection string 'TodoContextmapel' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
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
