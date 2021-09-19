using System.Threading;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using CarRental.Infrastructure.Persistence;
using CarRental.Web.Api.GraphQL.Rentals.Mutation.CreateRental;
using HotChocolate;
using HotChocolate.Data;

namespace CarRental.Web.Api.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<CreateRentalPayload> CreateRental(
            CreateRentalInput input,
            [ScopedService] ApplicationDbContext db,
            CancellationToken ct)
        {
            var rental = MapToRental(input);
            db.Add(rental);
            await db.SaveChangesAsync(ct);

            return new CreateRentalPayload(rental);
        }

        private static Rental MapToRental(CreateRentalInput input)
            => new ()
            {
                StartsAt = input.StartsAt,
                EndsAt = input.EndsAt,
                RenterFullName = input.RenterFullName,
                Notes = input.Notes,
                CarId = input.CarId
            };
    }
}