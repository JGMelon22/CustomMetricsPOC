using Microsoft.EntityFrameworkCore;
using CustomMetricsPOC.Infrastructure.Data;
using CustomMetricsPOC.Infrastructure.Repositories;
using CustomMetricsPOC.Interfaces;
using Prometheus;
using CustomMetricsPOC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddSingleton<OrderMetricsService>();
builder.Services.AddHostedService<MetricsBackgroundService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() | app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMetricServer();

app.UseHttpMetrics();

app.Run();
