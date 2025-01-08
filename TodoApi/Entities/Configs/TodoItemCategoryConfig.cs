using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApi.Entities.Configurations;

abstract class TodoItemCategoryConfig : IEntityTypeConfiguration<TodoItemCategory>
{

    public void Configure(EntityTypeBuilder<TodoItemCategory> builder) 
    {
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.CreatedAt)
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnAdd();
        builder.Property(c => c.UpdatedAt)
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnUpdate();

        builder.HasIndex(c => c.Name)
            .IsUnique();

        builder.HasMany(c => c.TodoItems)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
