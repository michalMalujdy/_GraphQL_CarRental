using System;
using System.Text.Json.Serialization;
using MediatR;

namespace CarRental.Application.Features.Cars.Commands.UpdateCar
{
    public class UpdateCarCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid CarId { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public int ProductionYear { get; set; }
    }
}