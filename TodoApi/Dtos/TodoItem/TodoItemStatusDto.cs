using TodoApi.Enums;
using TodoApi.Interfaces.Dtos.Common;

namespace TodoApi.Dtos.TodoItem;

public class TodoItemStatusDto : IDto
{
    public TodoItemStatus Status { get; set; }
}