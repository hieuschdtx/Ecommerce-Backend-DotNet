using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.ContactCommand.CreateContact
{
    public class CreateContactCommandHandler : ICommandHandler<CreateContactCommand, BaseResponseDto>
    {
        private readonly IContactRepository _contactRepository;

        public CreateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        public async Task<BaseResponseDto> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contacts(request.id.ToString(), request.name, request.email, request.message);
            await _contactRepository.AddAsync(contact);
            await _contactRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Tạo thành công");
        }
    }
}