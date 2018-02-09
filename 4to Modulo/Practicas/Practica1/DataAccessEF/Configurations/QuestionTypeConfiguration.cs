using DataAccessEF.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessEF.Configurations
{
    class QuestionTypeConfiguration : EntityTypeConfiguration<QuestionType>
    {
        public QuestionTypeConfiguration()
        {
            this.ToTable("QuestionTypes");

            this.HasKey(p => p.QuestionTypeId);

            this.Property(p => p.Description).HasMaxLength(200).IsRequired();
        }
    }
}
