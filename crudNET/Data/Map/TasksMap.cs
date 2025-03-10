using crudNET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crudNET.Data.Map
{
    public class TasksMap : IEntityTypeConfiguration<TasksModel>
    {
        public void Configure(EntityTypeBuilder<TasksModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
