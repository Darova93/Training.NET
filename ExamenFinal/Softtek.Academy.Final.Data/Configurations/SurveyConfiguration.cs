using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy.Final.Data.Configurations
{
    public class SurveyConfiguration : EntityTypeConfiguration<Survey>
    {
        public SurveyConfiguration()
        {
            this.ToTable("Surveys");
            this.HasKey(s => s.Id);
            this.Property(s => s.CreatedDate).IsRequired();
            this.Property(s => s.Title).HasMaxLength(50).IsRequired();
            this.Property(s => s.Description).HasMaxLength(200).IsRequired();
            this.Property(s => s.Status).IsRequired();
            this.Property(s => s.IsActive).IsRequired();
        }
    }
}
