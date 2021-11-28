using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IServiceProvider _serviceProvider;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, IServiceProvider serviceProvider)
        {
            _validators = validators;
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (failures.Count == 0)
                return await next();

            await InvokeValidationErrorHandler(request, cancellationToken, failures);

            throw new ValidationException(failures);

        }

        private async Task InvokeValidationErrorHandler(TRequest request, CancellationToken ct, List<ValidationFailure> failures)
        {
            var validationErrorHandler = _serviceProvider.GetService<IValidationErrorHandler<TRequest>>();

            if (validationErrorHandler != null)
                await validationErrorHandler.HandleValidationError(request, failures, ct);
        }
    }
}