using System;

namespace CarRental.Application.Features.Rentals.Queries.GetRentals
{
    public record GetRentalsResult(
        Guid Id,
        DateTimeOffset StartsAt,
        DateTimeOffset EndsAt,
        string RenterFullName,
        GetRentalsResult.CarResult Car)
    {
        public record CarResult(
            Guid Id,
            string Make,
            string Model,
            string RegistrationNumber,
            int ProductionYear,
            bool IsDeleted);
    }
}