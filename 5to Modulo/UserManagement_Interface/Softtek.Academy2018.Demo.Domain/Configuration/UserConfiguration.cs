using Softtek.Academy2018.Demo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Domain.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.ToTable("Users");
            this.HasKey(p => p.Id);
            this.Property(p => p.FirstName).IsRequired();
            this.Property(p => p.LastName).IsRequired();
            this.Property(p => p.CreatedDate).IsRequired();
        }
    }
}
