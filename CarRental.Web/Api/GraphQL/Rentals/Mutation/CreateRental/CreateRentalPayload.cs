using CarRental.Domain.Entities;

namespace CarRental.Web.Api.GraphQL.Rentals.Mutation.CreateRental
{
    public record CreateRentalPayload(Rental Rental);
}