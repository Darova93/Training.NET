using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ClassConfiguration : EntityTypeConfiguration<Class>
    {
        public ClassConfiguration()
        {
            this.ToTable("Classes");

            this.HasKey(p => p.ClassId);

            this.Property(p => p.SubjectId).IsRequired();

            this.Property(p => p.TeacherId).IsRequired();

            this.Property(p => p.Schedule).IsRequired();
        }
    }
}
