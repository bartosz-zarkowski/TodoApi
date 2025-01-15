using AutoMapper;
using TodoList.Api.Dtos.TodoItem;
using TodoList.Api.Entities;

namespace TodoList.Api.Mappings;

public class TodoItemProfile : Profile
{
    public TodoItemProfile()
    {
        CreateMap<TodoItem, TodoItemViewDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<TodoItemCreateDto, TodoItem>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));
        CreateMap<TodoItemUpdateDto, TodoItem>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));
        CreateMap<TodoItemStatusDto, TodoItem>();
    }
}
