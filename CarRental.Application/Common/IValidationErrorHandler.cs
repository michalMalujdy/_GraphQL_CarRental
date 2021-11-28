using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace CarRental.Application.Common
{
    public interface IValidationErrorHandler<in TRequest>
    {
        Task HandleValidationError(TRequest request, List<ValidationFailure> failures, CancellationToken ct);
    }
}