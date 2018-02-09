using DataAccessEF.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessEF.Configurations
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            this.ToTable("Questions");

            this.HasKey(p => p.QuestionId);

            this.Property(p => p.Text).HasMaxLength(200).IsRequired();

            this.Property(p => p.IsActive).IsRequired();

            this.Property(p => p.IsRequired).IsRequired();

            this.HasMany<Option>(op => op.Option)
                .WithMany(q => q.Questions)
                .Map(qo =>
                {
                    qo.MapLeftKey("QuestionId");
                    qo.MapRightKey("OptionID");
                    qo.ToTable("QuestionOptions");
                });
        }

    }
}
