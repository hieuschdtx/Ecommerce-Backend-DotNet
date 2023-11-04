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

        //var errors = _validators
        //  .Select(validation => validation.Validate(request))
        //  .SelectMany(validationResult => validationResult.Errors)
        //  .Where(validationFailure => validationFailure != null)
        //  .Select(c => new InvalidCommandException.InvalidCommandItemDto(c.PropertyName, c.ErrorMessage))
        //  .ToList();

        //if(errors.Any())
        //{
        //    throw new InvalidCommandException(errors[0].code, errors[0].message, errors);
        //}
        //return await next();

        var validationContext = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(validationContext, cancellationToken)));
        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        if(failures.Any())
        {
            var errors = failures.Select(failure => new InvalidCommandException.InvalidCommandItemDto(failure.PropertyName, failure.ErrorMessage)).ToList();
            throw new InvalidCommandException(errors[0].code, errors[0].message, errors);
        }

        return await next();
    }
}