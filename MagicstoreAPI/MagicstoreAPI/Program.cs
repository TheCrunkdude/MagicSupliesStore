using System;
using MagicstoreAPI;
using MagicstoreAPI.Middleware;
using MagicstoreAPI.Repositories;
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
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RolesService>();
builder.Services.AddScoped<RolesRepository>();
builder.Services.AddScoped<PermissionsService>();
builder.Services.AddScoped<PermissionsRepository>();

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

