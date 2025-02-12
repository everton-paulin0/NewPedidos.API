using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newpedidos.Application;
using Newpedidos.Application.Services;
using Newpedidos.Application.Services.Interfaces;
using NewPedidos.Infractruture.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("NewPedidoDb"));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));


builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();


//builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddApplication();
builder.Services.AddControllers();

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
