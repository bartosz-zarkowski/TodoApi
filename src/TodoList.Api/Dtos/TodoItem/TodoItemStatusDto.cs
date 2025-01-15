using TodoList.Api.Enums;
using TodoList.Api.Interfaces.Dtos.Common;

namespace TodoList.Api.Dtos.TodoItem;

public class TodoItemStatusDto : IDto
{
    public TodoItemStatus Status { get; set; }
}