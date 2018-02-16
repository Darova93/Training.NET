using Softtek.Academy2018.Demo.Domain.Configuration;
using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Data
{
    public class DBContext : DbContext
    {
        public DBContext() : base("EntityFramework")
        {
           //Database.SetInitializer<DBContext>(new DropCreateDatabaseAlways<DBContext>());
           Database.SetInitializer<DBContext>(new MigrateDatabaseToLatestVersion<DBContext, Migrations.Configuration>());
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
