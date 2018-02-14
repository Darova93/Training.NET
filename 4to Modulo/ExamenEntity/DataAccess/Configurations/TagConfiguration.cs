using DataAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configurations
{
    public class TagConfiguration : EntityTypeConfiguration<TagEF>
    {
        public TagConfiguration()
        {
            this.ToTable("Tags");
            this.HasKey(p => p.TagId);
            this.Property(p => p.Description).HasMaxLength(200).IsRequired();
        }
    }
}
