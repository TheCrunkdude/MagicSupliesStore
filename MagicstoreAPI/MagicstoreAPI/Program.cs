using MagicstoreAPI;
using MagicstoreAPI.Interfaces;
﻿using System;
using MagicstoreAPI.Middleware;
using MagicstoreAPI.Repositories;
using MagicstoreAPI.Repositories.Interfaces;
using MagicstoreAPI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCors", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});
//DB Context (Liga nuestro servidor SQL a la API)//
var connection = builder.Configuration.GetConnectionString("PostgresConnection");


if (builder.Configuration.GetValue<string>("DatabaseType") == "postgres")
{
    builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(connection));
}
else
{
    builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connection));

}

builder.Services.AddJWTTokenServices(builder.Configuration);

// Add services to the container.
builder.Services.AddScoped<IAuthenticationService1,AuthenticationService1>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IRolesRepository,RolesRepository>();
builder.Services.AddScoped<IPermissionsService, PermissionsService>();
builder.Services.AddScoped<IPermissionsRepository, PermissionsRepository>();
builder.Services.AddScoped<IRolePermissionsService, RolePermissionsService>();
builder.Services.AddScoped<IRolePermissionsRepository, RolePermissionsRepository>();
builder.Services.AddScoped<IUserRolesService, UserRolesService >();
builder.Services.AddScoped<IUserRolesRepository, UserRolesRepository>();



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
app.UseRouting();

app.UseMiddlewareFilter();

app.UseCors("AllowCors");

app.UseHttpsRedirection();

//Primero va autennticacion, luego la autorizacion!!
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

    app.Run();

