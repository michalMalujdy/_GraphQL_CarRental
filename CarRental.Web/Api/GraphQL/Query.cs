using System.Linq;
using CarRental.Domain.Entities;
using CarRental.Infrastructure.Persistence;
using HotChocolate;
using HotChocolate.Data;

namespace CarRental.Web.Api.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        [UseFiltering]
        public IQueryable<Car> GetCars([ScopedService] ApplicationDbContext applicationDb)
            => applicationDb.Cars;

        [UseDbContext(typeof(ApplicationDbContext))]
        [UseFiltering]
        public IQueryable<Rental> GetRentals([ScopedService] ApplicationDbContext applicationDb)
            => applicationDb.Rentals;
    }
}