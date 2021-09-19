using System.Threading;
using System.Threading.Tasks;
using CarRental.Application.Common;
using CarRental.Application.Features.Rentals.Commands;
using HotChocolate;
using MediatR;

namespace CarRental.Web.Api.GraphQL
{
    public class Mutation
    {
        private readonly ISender _sender;

        public Mutation([Service] ISender sender)
            => _sender = sender;

        public async Task<IdResult> CreateRental(
            CreateRentalCommand command,
            CancellationToken ct)
            => await _sender.Send(command, ct);
    }
}