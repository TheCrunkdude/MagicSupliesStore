using System;
using MagicstoreAPI.Infrastructures.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MagicstoreAPI
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)

        {
            InitalizeContext();


        }
        public DbSet<Users> MSDB_Users{ get; set; }
        public DbSet<Roles> MSDB_Roles { get; set; }
        public DbSet<Permissions> MSDB_Permissions { get; set; }

        //public DbSet<Permissions> MSDB_Permissions { get; set; }

        protected virtual void InitalizeContext()
        {
            // https://blog.oneunicorn.com/2012/03/12/secrets-of-detectchanges-part-3-switching-off-automatic-detectchanges/
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Database.SetCommandTimeout(360);
        }
    }
}

