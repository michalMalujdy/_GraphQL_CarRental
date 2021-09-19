using System;
using CarRental.Domain.Entities;
using MediatR;

namespace CarRental.Application.Features.Rentals.Commands
{
    public record CreateRentalCommand (
        DateTimeOffset StartsAt,
        DateTimeOffset EndsAt,
        string RenterFullName,
        string Notes,
        Guid CarId)
        : IRequest<Rental>;
}