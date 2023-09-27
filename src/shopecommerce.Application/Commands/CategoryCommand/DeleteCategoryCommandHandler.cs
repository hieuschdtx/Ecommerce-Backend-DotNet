using shopecommerce.Application.Services.CategoryService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.CategoryCommand
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, BaseResponseDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService, ICategoryRepository categoryRepository)
        {
            _categoryService = categoryService;
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponseDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if(!BaseGuidEx.IsGuid(request.category_id))
                throw new BusinessRuleException("category_id_is_invalid", CategoryMessages.category_id_is_invalid);

            var category = await _categoryRepository.GetByIdAsync(request.category_id) ?? throw new BusinessRuleException("category_is_not_exist", CategoryMessages.category_is_not_exist);

            await _categoryRepository.DeleteAsync(category);
            await _categoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Xóa danh mục thành công");
        }
    }
}
