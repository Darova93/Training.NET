using DataAccessEF.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessEF.Configurations
{
    public class OptionConfiguration : EntityTypeConfiguration<Option>
    {
       public OptionConfiguration()
        {
            this.ToTable("Options");

            this.HasKey(p => p.OptionId);

            this.Property(p => p.Text).HasMaxLength(200).IsRequired();
        }
    }
}
