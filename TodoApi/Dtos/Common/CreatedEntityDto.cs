using TodoApi.Interfaces.Dtos.Common;

namespace TodoApi.Dtos.Common;

public class CreatedEntityDto : IViewDto
{
    public Guid Id { get; set; }
}
