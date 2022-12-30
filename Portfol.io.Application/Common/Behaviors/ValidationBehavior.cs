using FluentValidation;
using MediatR;

namespace Portfol.io.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failres = _validators.Select(u => u.Validate(context)).SelectMany(u => u.Errors).Where(u => u != null).ToList();

            if (failres.Count != 0) throw new ValidationException(failres);

            return next();
        }
    }
}