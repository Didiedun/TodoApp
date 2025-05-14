using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApp.Core.Entities;

namespace TodoApp.Infrastructure.Persistence.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(t => t.Id);
            
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);
                
            builder.Property(t => t.Description)
                .HasMaxLength(1000);
                
            builder.Property(t => t.CreatedAt)
                .IsRequired();
        }
    }
}