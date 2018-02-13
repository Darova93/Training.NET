using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class AsignationConfiguration : EntityTypeConfiguration<Asignation>
    {
        public AsignationConfiguration()
        {
            this.ToTable("Asignations");

            this.HasKey(p => p.AsignationId);

            this.Property(p => p.ClassId).IsRequired();

            this.Property(p => p.StudentId).IsRequired();

            this.Property(p => p.Grade).IsRequired();
        }
    }
}
