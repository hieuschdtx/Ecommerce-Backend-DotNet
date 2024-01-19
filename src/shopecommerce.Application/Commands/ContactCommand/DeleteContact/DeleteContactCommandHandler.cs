using System.Net;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ContactCommand.DeleteContact
{
    public class DeleteContactCommandHandler : ICommandHandler<DeleteContactCommand, BaseResponseDto>
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<BaseResponseDto> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.id.ToString()) ??
                        throw new BusinessRuleException("contact_id_is_not_existed", "Contact id không tồn tại", HttpStatusCode.BadRequest);

            await _contactRepository.DeleteAsync(contact);
            await _contactRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Xoá thành công");
        }
    }
}