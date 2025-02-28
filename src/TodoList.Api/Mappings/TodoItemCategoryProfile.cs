﻿using AutoMapper;
using TodoList.Api.Database.Entities;
using TodoList.Api.Dtos.TodoItemCategory;

namespace TodoList.Api.Mappings;

public class TodoItemCategoryProfile : Profile
{
    public TodoItemCategoryProfile()
    {
        CreateMap<TodoItemCategory, TodoItemCategoryViewDto>();
        CreateMap<TodoItemCategoryCreateDto, TodoItemCategory>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));
        CreateMap<TodoItemCategoryUpdateDto, TodoItemCategory>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTimeOffset.UtcNow));
    }
}
