using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy.Final.Data.Configurations
{
    public class AnswerConfiguration : EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            this.ToTable("Answers");
            this.HasKey(a => a.Id);
            this.Property(a => a.CreatedDate).IsRequired();
            this.Property(a => a.SurveyId).IsRequired();
            this.Property(a => a.QuestionId).IsRequired();
            this.Property(a => a.OpenText).HasMaxLength(300);
            this.Property(a => a.Guest).HasMaxLength(100);
        }
    }
}
