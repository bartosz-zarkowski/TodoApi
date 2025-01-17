using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Api.Database.Entities;

namespace TodoList.Api.Database.Configs;

abstract class TodoItemConfig : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.Property(i => i.Id).ValueGeneratedOnAdd();
        builder.Property(i => i.CreatedAt)
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnAdd();
        builder.Property(i => i.UpdatedAt)
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnUpdate();


        builder.HasOne(i => i.Category)
            .WithMany(c => c.TodoItems)
            .HasForeignKey(i => i.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
