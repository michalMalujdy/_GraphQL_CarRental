using System;
using System.Text.Json.Serialization;
using MediatR;

namespace CarRental.Application.Features.Rentals.Commands.UpdateRental
{
    public class UpdateRentalCommand : IRequest
    {
        [JsonIgnore]
        public Guid RentalId { get; set; }
        
        public DateTimeOffset StartsAt { get; set; }
        public DateTimeOffset EndsAt { get; set; }
        public string RenterFullName { get; set; }
        public string Notes { get; set; }
        public Guid CarId { get; set; }
    }
}