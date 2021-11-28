using CarRental.Application.Common.Results;
using MediatR;

namespace CarRental.Application.Features.Cars.Commands.CreateCar
{
    public record CreateCarCommand(
            string Make,
            string Model,
            string RegistrationNumber,
            int ProductionYear)
        : IRequest<IdResult>;
}