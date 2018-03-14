using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy.Final.Data.Configurations
{
    public class QuestionTypeConfiguration : EntityTypeConfiguration<QuestionType>
    {
        public QuestionTypeConfiguration()
        {
            this.ToTable("QuestionTypes");
            this.HasKey(q => q.Id);
            this.Property(q => q.CreatedDate).IsRequired();
            this.Property(q => q.Description).HasMaxLength(200).IsRequired();
        }
    }
}
