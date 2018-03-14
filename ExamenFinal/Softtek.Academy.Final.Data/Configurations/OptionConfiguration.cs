using Softtek.Academy.Final.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy.Final.Data.Configurations
{
    public class OptionConfiguration : EntityTypeConfiguration<Option>
    {
        public OptionConfiguration()
        {
            this.ToTable("Options");
            this.HasKey(o => o.Id);
            this.Property(o => o.CreatedDate).IsRequired();
            this.Property(o => o.Text).HasMaxLength(200).IsRequired();
            this.Property(o => o.QuestionId).IsRequired();
        }
    }
}
