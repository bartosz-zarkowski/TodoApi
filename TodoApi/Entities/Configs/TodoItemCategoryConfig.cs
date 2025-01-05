using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApi.Entities.Configurations;

abstract class TodoItemCategoryConfig : IEntityTypeConfiguration<ToDoItemCategory>
{

    public void Configure(EntityTypeBuilder<ToDoItemCategory> builder) 
    {
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.CreatedAt).ValueGeneratedOnAdd();
        builder.Property(c => c.UpdatedAt).ValueGeneratedOnUpdate();

        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.HasMany(c => c.TodoItems)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
