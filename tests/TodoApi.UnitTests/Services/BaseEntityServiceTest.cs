using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using TodoList.Api.Exceptions;
using TodoList.Api.Interfaces.Dtos.Common;
using TodoList.Api.Interfaces.Entities;
using TodoList.Api.Interfaces.Repositories;
using TodoList.Api.Interfaces.Services;

namespace TodoList.UnitTests.Services;

public abstract class BaseEntityServiceTest<TEntity, TViewDto, TCreateDto, TUpdateDto, TService, TRepository>
    where TEntity : class, IEntity
    where TViewDto : class, IViewDto
    where TCreateDto : class, IDto
    where TUpdateDto : class, IDto
    where TService : class, IEntityService<TEntity, TViewDto, TCreateDto, TUpdateDto>
    where TRepository : class, IEntityRepository<TEntity>
{
    protected abstract TService CreateService();

    protected TService _service;
    protected readonly Mock<TRepository> _repositoryMock;
    protected readonly Mock<IMapper> _mapperMock;
    protected readonly Mock<IValidator<TEntity>> _validatorMock;

    public BaseEntityServiceTest()
    {
        _repositoryMock = new Mock<TRepository>();
        _mapperMock = new Mock<IMapper>();
        _validatorMock = new Mock<IValidator<TEntity>>();
        _service = CreateService();
    }

    [Fact]
    public virtual async Task GetByIdAsync_ForNotExistingEntity_ThrowsNotFoundException()
    {
        Guid entityId = Entity.Id;
        TEntity entity = Entity;

        _repositoryMock.Setup(r => r.FindByIdAsync(entityId))
            .ReturnsAsync(null as TEntity);;

        var serviceGetByIdAsync = () => _service.GetByIdAsync(entityId);

        await serviceGetByIdAsync.Should().ThrowAsync<NotFoundException>();
        _repositoryMock.Verify(r => r.FindByIdAsync(entityId), Times.Once);
    }

    [Fact]
    public virtual async Task GetByIdAsync_ForExistingEntity_returnsViewDto()
    {
        Guid entityId = Entity.Id;
        TEntity entity = Entity;
        TViewDto viewDto = ViewDto;

        _repositoryMock.Setup(r => r.FindByIdAsync(entityId))
            .ReturnsAsync(entity);
        _mapperMock.Setup(m => m.Map<TViewDto>(entity))
            .Returns(viewDto);

        TViewDto? viewDtoResponse = await _service.GetByIdAsync(entityId);

        viewDtoResponse.Should().NotBeNull();
        _repositoryMock.Verify(r => r.FindByIdAsync(entityId), Times.Once);
        _mapperMock.Verify(m => m.Map<TViewDto>(entity), Times.Once);
    }

    [Fact]
    public virtual async Task GetAllAsync_ReturnsCollectionOfEntities()
    {
        TEntity entity = Entity;
        TViewDto viewDto = ViewDto;

        IEnumerable<TEntity> entities = new List<TEntity> { entity };
        IEnumerable<TViewDto> viewDtos = new List<TViewDto> { viewDto };

        _repositoryMock.Setup(r => r.FindAllAsync(null))
            .ReturnsAsync(entities);
        _mapperMock.Setup(m => m.Map<IEnumerable<TViewDto>>(entities))
            .Returns(viewDtos);

        IEnumerable<TViewDto> viewDtosResponse = await _service.GetAllAsync();

        viewDtosResponse.Should().NotBeEmpty();
        _repositoryMock.Verify(r => r.FindAllAsync(null), Times.Once);
        _mapperMock.Verify(m => m.Map<IEnumerable<TViewDto>>(entities), Times.Once);
    }

    [Fact]
    public virtual async Task CreateAsync_ForValidModel_CreatesEntityAndReturnsViewDto()
    {
        TCreateDto createDto = CreateDto;
        TEntity entity = Entity;
        TViewDto viewDto = ViewDto;

        _mapperMock.Setup(m => m.Map<TEntity>(createDto))
            .Returns(entity);
        _mapperMock.Setup(m => m.Map<TViewDto>(entity))
            .Returns(viewDto);

        TViewDto viewDtoResponse = await _service.CreateAsync(createDto);

        viewDtoResponse.Should().BeEquivalentTo(viewDto);
        _mapperMock.Verify(m => m.Map<TEntity>(createDto), Times.Once);
        _repositoryMock.Verify(r => r.CreateAsync(entity), Times.Once);
        _mapperMock.Verify(m => m.Map<TViewDto>(entity), Times.Once);
    }

    [Fact]
    public virtual async Task UpdateById_ForNotExistingEntity_ThrowsNotFoundException()
    {
        Guid entityId = Entity.Id;
        TUpdateDto updateDto = UpdateDto;

        _repositoryMock.Setup(r => r.FindByIdAsync(entityId))
            .ReturnsAsync(null as TEntity);

        var serviceUpdateByIdAsync = () => _service.UpdateByIdAsync(entityId, updateDto);

        await serviceUpdateByIdAsync.Should().ThrowAsync<NotFoundException>();
        _repositoryMock.Verify(r => r.FindByIdAsync(entityId), Times.Once);
    }

    [Fact]
    public virtual async Task UpdateById_ForExistingEntity_UpdatesEntityAndReturnsDto()
    {
        Guid entityId = Entity.Id;
        TUpdateDto updateDto = UpdateDto;
        TEntity entity = Entity;
        TViewDto viewDto = ViewDto;

        _repositoryMock.Setup(r => r.FindByIdAsync(entityId))
            .ReturnsAsync(entity);
        _mapperMock.Setup(m => m.Map<TViewDto>(entity))
            .Returns(viewDto);

        TViewDto? viewDtoResponse = await _service.UpdateByIdAsync(entityId, updateDto);

        viewDtoResponse.Should().NotBeNull();
        _repositoryMock.Verify(r => r.FindByIdAsync(entityId), Times.Once);
        _mapperMock.Verify(m => m.Map(updateDto, entity), Times.Once);
        _repositoryMock.Verify(r => r.UpdateAsync(entity), Times.Once);
        _mapperMock.Verify(m => m.Map<TViewDto>(entity), Times.Once);
    }

    [Fact]
    public virtual async Task DeleteByIdAsync_DeletesEntity()
    {
        Guid entityId = Entity.Id;

        await _service.DeleteByIdAsync(entityId);

        _repositoryMock.Verify(r => r.DeleteByIdAsync(entityId), Times.Once);
    }

    protected abstract TEntity Entity { get; }
    protected abstract TViewDto ViewDto { get; }
    protected abstract TCreateDto CreateDto { get; }
    protected abstract TUpdateDto UpdateDto { get; }
}
