using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Interfaces.Dtos.Common;
using TodoList.Api.Interfaces.Entities;
using TodoList.Api.Interfaces.Services;

namespace TodoList.Api.Controllers;

[ApiController]
public abstract class BaseController<TEntity, TViewDto, TCreateDto, TUpdateDto> : ControllerBase
    where TEntity : class, IEntity
    where TViewDto : class, IViewDto
    where TCreateDto : class, IDto
    where TUpdateDto : class, IDto
{

    private readonly IEntityService<TEntity, TViewDto, TCreateDto, TUpdateDto> _service;

    public BaseController(IEntityService<TEntity, TViewDto, TCreateDto, TUpdateDto> service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}")]
    public virtual async Task<ActionResult<TViewDto>> GetById(Guid id)
    {
        TViewDto? viewDto = await _service.GetByIdAsync(id);

        if (viewDto == null)
        {
            return NotFound();
        }

        return Ok(viewDto);
    }

    [HttpGet]
    public virtual async Task<ActionResult<IEnumerable<TViewDto>>> GetAll()
    {
        IEnumerable<TViewDto> viewDtos = await _service.GetAllAsync();

        return Ok(viewDtos);
    }

    [HttpPost]
    public async Task<ActionResult<TViewDto>> PostAsync([FromBody] TCreateDto createDto)
    {
        TViewDto viewDto = await _service.CreateAsync(createDto);

        return CreatedAtAction(nameof(GetById), new { id = viewDto.Id }, new { id = viewDto.Id });
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<TViewDto>> PutAsync(Guid id, [FromBody] TUpdateDto updateDto)
    {
        TViewDto? viewDto = await _service.UpdateByIdAsync(id, updateDto);

        if (viewDto == null)
        {
            return NotFound();
        }

        return Ok(viewDto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var viewDto = await _service.GetByIdAsync(id);

        if (viewDto == null)
        {
            return NotFound();
        }

        await _service.DeleteByIdAsync(id);

        return NoContent();
    }
}
