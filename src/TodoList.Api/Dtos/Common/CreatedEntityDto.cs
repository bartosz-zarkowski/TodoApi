using TodoList.Api.Interfaces.Dtos.Common;

namespace TodoList.Api.Dtos.Common;

public class CreatedEntityDto : IViewDto
{
    public Guid Id { get; set; }
}
