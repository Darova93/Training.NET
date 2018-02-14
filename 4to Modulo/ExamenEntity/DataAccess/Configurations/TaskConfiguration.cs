using DataAccess.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configurations
{
    public class TaskConfiguration : EntityTypeConfiguration<TaskEF>
    {
        public TaskConfiguration()
        {
            this.ToTable("Tasks");
            this.HasKey(p => p.TaskId);
            this.Property(p => p.Title).HasMaxLength(100).IsRequired();
            this.Property(p => p.Description).HasMaxLength(200).IsRequired();
            this.Property(p => p.Status).IsRequired();
            this.Property(p => p.IsArchived).IsRequired();
            this.Property(p => p.DueDate).IsRequired();
            this.HasMany<TagEF>(t => t.Tags)
                .WithMany(tk => tk.Tasks)
                .Map(ttk =>
                {
                    ttk.MapLeftKey("TaskId");
                    ttk.MapRightKey("TagId");
                    ttk.ToTable("ItemTags");
                });
        }
    }
}
