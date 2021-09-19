using System.Threading;
using System.Threading.Tasks;
using CarRental.Application.Common;
using CarRental.Application.Common.Results;
using CarRental.Application.Features.Rentals.Commands.CreateRental;
using CarRental.Application.Features.Rentals.Commands.DeleteRental;
using CarRental.Application.Features.Rentals.Commands.UpdateRental;
using HotChocolate;
using MediatR;

namespace CarRental.Web.Api.GraphQL
{
    public class Mutation
    {
        public async Task<IdResult> CreateRental(CreateRentalCommand command, [Service] ISender mediator, CancellationToken ct)
            => await mediator.Send(command, ct);

        public async Task<Empty> UpdateRental(UpdateRentalCommand command, [Service] ISender mediator, CancellationToken ct)
        {
            await mediator.Send(command, ct);
            return new Empty();
        }

        public async Task<Empty> DeleteRental(DeleteRentalCommand command, [Service] ISender mediator, CancellationToken ct)
        {
            await mediator.Send(command, ct);
            return new Empty();
        }
    }
}