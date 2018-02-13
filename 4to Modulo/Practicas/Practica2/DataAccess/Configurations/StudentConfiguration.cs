using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            this.ToTable("Students");

            this.HasKey(p => p.StudentID);

            this.Property(p => p.Name).HasMaxLength(50).IsRequired();

            this.Property(p => p.LastName).HasMaxLength(50).IsRequired();

            this.Property(p => p.Age).IsRequired();

            this.Property(p => p.Email).HasMaxLength(50).IsRequired();
        }
    }
}
