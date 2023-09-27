using AutoMapper;
using shopecommerce.Application.Services.CategoryService;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.CategoryCommand;

public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, BaseResponseDto>
{
    private readonly ICategoryService _categoryService;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryService categoryService, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryService = categoryService;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if(await _categoryService.NameExistsAsync(request.name))
        {
            throw new BusinessRuleException("category_name_exist", CategoryMessages.category_name_exist);
        }
        var dataCategory = _mapper.Map(request, new Categories());
        dataCategory.CreateTime();
        await _categoryRepository.AddAsync(dataCategory);
        await _categoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

        return new BaseResponseDto(true, "Thêm mới danh mục thành công", dataCategory);
    }
}