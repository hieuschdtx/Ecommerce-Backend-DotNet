using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using shopecommerce.Application.Services.CategoryService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.CategoryCommand.CreateCategory;

public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, BaseResponseDto>
{
    private readonly ICategoryService _categoryService;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IHubContext<DataHub> _hubContext;

    public CreateCategoryCommandHandler(ICategoryService categoryService, ICategoryRepository categoryRepository, IMapper mapper, IHubContext<DataHub> hubContext)
    {
        _categoryService = categoryService;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _hubContext = hubContext;
    }

    public async Task<BaseResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if(await _categoryService.NameExistsAsync(request.name))
        {
            return new BaseResponseDto(false, CategoryMessages.category_name_exist, (int)HttpStatusCode.BadRequest);
        }

        var dataCategory = _mapper.Map(request, new Categories());
        dataCategory.CreateTime();

        await _categoryRepository.AddAsync(dataCategory);
        await _categoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

        await _hubContext.Clients.All.SendAsync("RELOAD_DATA_CHANGE", cancellationToken: cancellationToken);

        return new BaseResponseDto(true, "Thêm mới danh mục thành công", (int)HttpStatusCode.Created, dataCategory);
    }
}