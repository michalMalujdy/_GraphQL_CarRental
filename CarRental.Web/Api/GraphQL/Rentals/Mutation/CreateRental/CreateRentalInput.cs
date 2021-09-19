using System;

namespace CarRental.Web.Api.GraphQL.Rentals.Mutation.CreateRental
{
    public record CreateRentalInput(
        DateTimeOffset StartsAt,
        DateTimeOffset EndsAt,
        string RenterFullName,
        string Notes,
        Guid CarId);
}