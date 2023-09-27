using AutoMapper;
using shopecommerce.Application.Services.CategoryService;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.CategoryCommand
{
    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, BaseResponseDto>
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, ICategoryService categoryService)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryService = categoryService;
        }
        public async Task<BaseResponseDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.id.ToString()) ?? throw new BusinessRuleException("category_is_not_exist", CategoryMessages.category_is_not_exist);

            var result = _mapper.Map(request, category);
            result.UpdateModifiedTime();

            await _categoryRepository.UpdateAsync(result);
            await _categoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Cập nhật danh mục thành công");
        }
    }
}
