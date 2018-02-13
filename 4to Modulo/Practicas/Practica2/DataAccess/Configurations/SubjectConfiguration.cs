using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration()
        {
            this.ToTable("Subjects");

            this.HasKey(p => p.SubjectId);

            this.Property(p => p.Description).HasMaxLength(50).IsRequired();

            this.Property(p => p.Credits).IsRequired();

            this.Property(p => p.TeacherId).IsRequired();
        }
    }
}
