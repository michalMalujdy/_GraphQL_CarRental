using CarRental.Domain.Entities;
using CarRental.Infrastructure.Persistence;
using HotChocolate.Types;

namespace CarRental.Web.Api.GraphQL.Rentals
{
    public class RentalType : ObjectType<Rental>
    {
        protected override void Configure(IObjectTypeDescriptor<Rental> descriptor)
        {
            descriptor.Description("An object that represents renting of a car");

            descriptor.Field(r => r.Car)
                .ResolveWith<RentalResolvers>(r => r.GetCars(default!, default!))
                .UseDbContext<ApplicationDbContext>();
        }
    }
}