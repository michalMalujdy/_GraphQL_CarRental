using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Features.Rentals.Commands.UpdateRental
{
    public class UpdateRentalHandler : IRequestHandler<UpdateRentalCommand>
    {
        private readonly IApplicationDbContext _db;

        public UpdateRentalHandler(IApplicationDbContext db)
            => _db = db;

        public async Task<Unit> Handle(UpdateRentalCommand command, CancellationToken ct)
        {
            var rental = await GetRental(command, ct);
            MapToRental(rental, command);
            await _db.SaveChangesAsync(ct);

            return Unit.Value;
        }

        private async Task<Rental> GetRental(UpdateRentalCommand command, CancellationToken ct)
            => await _db.Rentals
                .Where(r => r.Id == command.RentalId)
                .SingleOrDefaultAsync(ct);

        private static void MapToRental(Rental rental, UpdateRentalCommand command)
        {
            rental.StartsAt = command.StartsAt;
            rental.EndsAt = command.EndsAt;
            rental.RenterFullName = command.RenterFullName;
            rental.Notes = command.Notes;
            rental.CarId = command.CarId;
        }
    }
}