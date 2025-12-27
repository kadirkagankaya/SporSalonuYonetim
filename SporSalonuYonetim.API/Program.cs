using Microsoft.EntityFrameworkCore;
using SporSalonuYonetim.API.Middlewares;
using SporSalonuYonetim.Core.Interfaces;
using SporSalonuYonetim.Data.Context;
using SporSalonuYonetim.Data.Repositories;
using SporSalonuYonetim.Service.Mapping;
using SporSalonuYonetim.Service.Services;
using Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<SporSalonuContext>(options =>
    options.UseMongoDB(builder.Configuration.GetConnectionString("MongoDbConnection"), "SporSalonuDb"));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IService<>), typeof(GenericService<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();

SporSalonuYonetim.API.Modules.MinimalApiEndpoints.RegisterMinimalEndpoints(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
