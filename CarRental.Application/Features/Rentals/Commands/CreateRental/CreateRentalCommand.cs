using System;
using CarRental.Application.Common;
using CarRental.Application.Common.Results;
using MediatR;

namespace CarRental.Application.Features.Rentals.Commands.CreateRental
{
    public record CreateRentalCommand(
            DateTimeOffset StartsAt,
            DateTimeOffset EndsAt,
            string RenterFullName,
            string? Notes,
            Guid CarId)
        : IRequest<IdResult>;
}