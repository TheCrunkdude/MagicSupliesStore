using System;
using MagicstoreAPI.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MagicstoreAPI
{
    public class ApplicationDBContext : DbContext
    {
        private IConfiguration _configuration;
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;

            if (_configuration.GetValue<string>("DatabaseType") == "postgres")
            {

            }
            else
            {
            InitalizeContext();

            }
        }
        public DbSet<Users> MSDB_Users{ get; set; }
        public DbSet<Roles> MSDB_Roles { get; set; }
        public DbSet<Permissions> MSDB_Permissions { get; set; }
        public DbSet<RolePermissions> MSDB_RolesPermissions { get; set; }


        protected virtual void InitalizeContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Database.SetCommandTimeout(360);
        }
    }
}

