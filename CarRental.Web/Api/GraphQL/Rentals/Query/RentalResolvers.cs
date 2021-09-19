using System.Linq;
using CarRental.Domain.Entities;
using CarRental.Infrastructure.Persistence;
using HotChocolate;

namespace CarRental.Web.Api.GraphQL.Rentals.Query
{
    public class RentalResolvers
    {
        public IQueryable<Car> GetCars(Rental rental, [ScopedService] ApplicationDbContext db)
            => db.Cars.Where(c => c.Id == rental.CarId);
    }
}