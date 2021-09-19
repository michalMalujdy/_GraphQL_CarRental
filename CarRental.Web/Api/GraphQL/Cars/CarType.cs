using CarRental.Domain.Entities;
using CarRental.Infrastructure.Persistence;
using HotChocolate.Types;

namespace CarRental.Web.Api.GraphQL.Cars
{
    public class CarType : ObjectType<Car>
    {
        protected override void Configure(IObjectTypeDescriptor<Car> descriptor)
        {
            descriptor.Description("A car within rental car pool");

            descriptor
                .Field(c => c.Rentals)
                .ResolveWith<CarResolvers>(cr => cr.GetRentals(default!, default!))
                .UseDbContext<ApplicationDbContext>();
        }
    }
}