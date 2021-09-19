using System.Linq;
using CarRental.Domain.Entities;
using CarRental.Infrastructure.Persistence;
using HotChocolate;

namespace CarRental.Web.Api.GraphQL.Cars
{
    public class CarResolvers
    {
        public IQueryable<Rental> GetRentals(Car car, [ScopedService] ApplicationDbContext db)
            => db.Rentals.Where(r => r.CarId == car.Id);
    }
}