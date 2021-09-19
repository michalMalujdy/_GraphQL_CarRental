using System;
using MediatR;

namespace CarRental.Application.Features.Rentals.Commands.DeleteRental
{
    public record DeleteRentalCommand(Guid RentalId) : IRequest;
}