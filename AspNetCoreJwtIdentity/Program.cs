using AspNetCoreJwtIdentity.Filters;
using AspNetCoreJwtIdentity.Policies;
using AspNetCoreJwtIdentity.Repositories.MediatR;
using AspNetCoreJwtIdentity.Services;
using BusinessLayer;
using BusinessLayer.ServiceExtentions;
using Entities;
using Entities.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// authentication : https://lab.cliel.com/entry/ASPNET-Core-Web-API-JWT-%EC%9D%B8%EC%A6%9D
/*
 * ValidateIssuer는 Issuer의 유효성여부를 ValidAudience는 Audiance의 유효성 여부, 
 * ValidateLifetime는 Token의 생명주기를, ValidateIssuerSigningKey는 Token의 유효성을 검증할지 설정
 */

var appSettings = new ConfigurationService(builder.Configuration).AppSettings();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy(IdentityPolicy.Admin, IdentityPolicy.AdminPolicy());
    config.AddPolicy(IdentityPolicy.User, IdentityPolicy.UserPolicy());
});

//--------------------------------------------------------------------------

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
    });
    c.OperationFilter<SwaggerAuthorizeCheckOperationFilter>();
});

//**************** InMemoryDatabase
//builder.Services.AddDbContext<IIdentityContext, IdentityContext>(opt => opt.UseInMemoryDatabase(databaseName: "AspNetCoreJwtIdentity"));
var _connection = new SqliteConnection("Filename=:memory:");
_connection.Open();
var options = new DbContextOptionsBuilder<IdentityContext>()
                .UseSqlite(_connection)
                .Options;

builder.Services.AddDbContext<IIdentityContext, IdentityContext>(opt => opt.UseSqlite(_connection));
builder.Services.AddScoped<IIdentityContext, IdentityContext>();

//builder.Services.AddUserService();
//mediatR
//builder.Services.AddSingleton<IDataAccess, DataAccess>();
builder.Services.AddMediatR(typeof(BusinessLayerBootstrap).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

var contextScope = app.Services.CreateScope();
var context = contextScope.ServiceProvider.GetRequiredService<IdentityContext>(); 
IdentityContextInitializeDatabase.InitDatabaseAsync(context).GetAwaiter().GetResult();

app.Run();
