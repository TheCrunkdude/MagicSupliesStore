using MagicstoreAPI;
using MagicstoreAPI.Interfaces;
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
var connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(connection));

// Add services to the container.
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IRolesRepository,RolesRepository>();
builder.Services.AddScoped<IPermissionsService, PermissionsService>();
builder.Services.AddScoped<IPermissionsRepository, PermissionsRepository>();


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

app.UseCors("AllowCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

