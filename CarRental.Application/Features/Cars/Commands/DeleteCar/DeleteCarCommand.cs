using System;
using MediatR;

namespace CarRental.Application.Features.Cars.Commands.DeleteCar
{
    public class DeleteCarCommand : IRequest
    {
        public Guid CarId { get; set; }
    }
}