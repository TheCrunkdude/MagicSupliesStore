using System;
using MagicstoreAPI.Infrastructures.Entities;
using MagicstoreAPI.Infrastructures.Entities.SeedData;
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
        public DbSet<UserRoles> MSDB_UserRoles { get; set; }
        public DbSet<Beers> cervezas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Beers>().HasKey(b => b.id);
            modelBuilder.Entity<Beers>().HasData(BeersSeedData.beers());


            modelBuilder.Entity<Users>().HasKey(b => b.ID);
            modelBuilder.Entity<Users>().HasData(UsersSeedData.usersSeed());


            modelBuilder.Entity<Roles>().HasKey(b => b.ID);
            modelBuilder.Entity<Roles>().HasData(RolesSeedData.rolesSeed());



            modelBuilder.Entity<Permissions>().HasKey(b => b.ID);
            modelBuilder.Entity<Permissions>().HasData(PermissionsSeedData.permissionsSeed());


            modelBuilder.Entity<RolePermissions>().HasKey(b => b.ID);
            modelBuilder.Entity<RolePermissions>().HasData(RolePermissionsSeedData.rolesPermissionsSeed());


            modelBuilder.Entity<UserRoles>().HasKey(b => b.ID);
            modelBuilder.Entity<UserRoles>().HasData(UserRolesSeedData.userRolesSeed());


        }

        protected virtual void InitalizeContext()
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Database.SetCommandTimeout(360);
        }
    }
}

