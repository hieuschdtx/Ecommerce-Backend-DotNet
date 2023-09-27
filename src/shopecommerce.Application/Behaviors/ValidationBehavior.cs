using FluentValidation;
using MediatR;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;

namespace shopecommerce.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
  where TRequest : class, ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request,
      RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(!_validators.Any())
            return await next();

        var errors = _validators
          .Select(validation => validation.Validate(request))
          .SelectMany(validationResult => validationResult.Errors)
          .Where(validationFailure => validationFailure != null)
          .Select(c => new InvalidCommandException.InvalidCommandItemDto(c.PropertyName, c.ErrorMessage))
          .ToList();

        if(errors.Any())
        {
            throw new InvalidCommandException(errors[0].code, errors[0].message, errors);
        }
        return await next();
    }
}