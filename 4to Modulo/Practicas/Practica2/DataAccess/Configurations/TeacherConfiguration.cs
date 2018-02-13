using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class TeacherConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfiguration()
        {
            this.ToTable("Teachers");

            this.HasKey(p => p.TeacherId);

            this.Property(p => p.Name).HasMaxLength(50).IsRequired();

            this.Property(p => p.LastName).HasMaxLength(50).IsRequired();

            this.Property(p => p.Telephone).HasMaxLength(10).IsRequired();

            this.Property(p => p.Email).HasMaxLength(50).IsRequired();
        }
    }
}
