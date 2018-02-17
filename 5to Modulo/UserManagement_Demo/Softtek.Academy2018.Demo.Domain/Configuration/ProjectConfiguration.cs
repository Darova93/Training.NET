using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Domain.Configuration
{
    public class ProjectConfiguration : EntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
            this.ToTable("Projects");
            this.HasKey(x => x.Id);
            this.Property(p => p.Name).IsRequired();
            this.Property(p => p.Area).IsRequired();
            this.Property(p => p.TechnologyStack).IsRequired();
            this.HasMany<User>(x => x.Contributors)
                .WithMany(x => x.UserProjects)
                .Map(up =>
                {
                    up.MapLeftKey("ProjectId");
                    up.MapRightKey("UserId");
                    up.ToTable("UsersProjects");
                });
        }
    }
}
