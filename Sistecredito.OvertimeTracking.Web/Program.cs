using AutoMapper;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Localization;
using Sistecredito.OvertimeTracking.Application.Config;
using Sistecredito.OvertimeTracking.Application.Dtos.Core;
using Sistecredito.OvertimeTracking.Application.Interfaces;
using Sistecredito.OvertimeTracking.Application.Interfaces.Authentication;
using Sistecredito.OvertimeTracking.Application.Interfaces.Core;
using Sistecredito.OvertimeTracking.Application.Services;
using Sistecredito.OvertimeTracking.Application.Services.Authentication;
using Sistecredito.OvertimeTracking.Core.Interfaces;
using Sistecredito.OvertimeTracking.Core.Interfaces.Repositories;
using Sistecredito.OvertimeTracking.Infrastructure.Data;
using Sistecredito.OvertimeTracking.Infrastructure.Helpers.Authentication;
using Sistecredito.OvertimeTracking.Infrastructure.Identity;
using Sistecredito.OvertimeTracking.Infrastructure.Interfaces.Authentication;
using Sistecredito.OvertimeTracking.Infrastructure.Repositories;
using Sistecredito.OvertimeTracking.Infrastructure.Repositories.Authentication;
using Sistecredito.OvertimeTracking.Infrastructure.Repositories.Core;
using Sistecredito.OvertimeTracking.Infrastructure.Resources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting();

// Configuración de la conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configuración de la bd para el contexto de Identity
builder.Services.AddDbContext<AutenticationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AutenticationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IDesignTimeDbContextFactory<AutenticationDbContext>, AutenticationDbContextFactory>();

// Configuración de la bd para el contexto de aplicación
// Register ApplicationDbContext and configure it
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Configuración de autenticación y autorización 
builder.Services.AddAuthentication().AddCookie();
builder.Services.AddAuthorization();

// Configuraciones adicionales
builder.Services.Configure<IdentityOptions>(options =>
{
    // Configuración de contraseñas
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
});

// Configure dependency inyection
var dependencyInjectionConfig = new DependencyInjectionConfig();
dependencyInjectionConfig.ConfigureServices(builder.Services);

// Configuración Automapper
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var configMapper = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

var mapper = configMapper.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Uso de autenticación y autorización 
app.UseAuthorization();
app.UseAuthentication();

app.UseRouting();

app.MapControllers();

app.Run();
