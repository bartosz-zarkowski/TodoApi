using TodoApi.Interfaces.Dtos;

namespace TodoApi.Dtos.Common;

public class CreatedEntityDto : IViewDto
{
    public Guid Id { get; set; }
}
