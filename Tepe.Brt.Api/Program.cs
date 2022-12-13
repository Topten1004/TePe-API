using Microsoft.EntityFrameworkCore;
using Tepe.Brt.Api;
using Tepe.Brt.Api.Services;
using Tepe.Brt.Data;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation( c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database DI
builder.Services.AddDbContext<ApplicationDbContext>(
  option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
  sqlServerOptionsAction: sqlOptions =>
  {
      sqlOptions.EnableRetryOnFailure();
  }));

// Auto maper DI
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
ApplicationServices.AddServices(builder.Services);

var app = builder.Build();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();