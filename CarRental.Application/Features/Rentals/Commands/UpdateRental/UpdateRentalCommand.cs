using System;
using MediatR;

namespace CarRental.Application.Features.Rentals.Commands.UpdateRental
{
    public record UpdateRentalCommand(
            Guid RentalId,
            DateTimeOffset StartsAt,
            DateTimeOffset EndsAt,
            string RenterFullName,
            string? Notes,
            Guid CarId)
        : IRequest;
}