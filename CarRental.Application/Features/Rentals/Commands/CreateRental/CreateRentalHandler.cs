using System.Threading;
using System.Threading.Tasks;
using CarRental.Application.Common;
using CarRental.Application.Common.Results;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;

namespace CarRental.Application.Features.Rentals.Commands.CreateRental
{
    public class CreateRentalHandler : IRequestHandler<CreateRentalCommand, IdResult>
    {
        private readonly IApplicationDbContext _db;

        public CreateRentalHandler(IApplicationDbContext db)
            => _db = db;

        public async Task<IdResult> Handle(CreateRentalCommand command, CancellationToken ct)
        {
            var rental = MapToRental(command);
            _db.Rentals.Add(rental);
            await _db.SaveChangesAsync(ct);

            return new IdResult(rental.Id);
        }

        private static Rental MapToRental(CreateRentalCommand command)
            => new ()
            {
                StartsAt = command.StartsAt,
                EndsAt = command.EndsAt,
                RenterFullName = command.RenterFullName,
                Notes = command.Notes,
                CarId = command.CarId
            };
    }
}