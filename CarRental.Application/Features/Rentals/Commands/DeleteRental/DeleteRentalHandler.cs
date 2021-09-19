using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Features.Rentals.Commands.DeleteRental
{
    public class DeleteRentalHandler : IRequestHandler<DeleteRentalCommand>
    {
        private readonly IApplicationDbContext _db;

            public DeleteRentalHandler(IApplicationDbContext db)
                => _db = db;

        public async Task<Unit> Handle(DeleteRentalCommand command, CancellationToken ct)
        {
            var rental = await GetRental(command.RentalId, ct);
            rental.IsDeleted = true;
            await _db.SaveChangesAsync(ct);

            return Unit.Value;
        }

        private async Task<Rental> GetRental(Guid rentalId, CancellationToken ct)
            => await _db.Rentals
                .Where(r => r.Id == rentalId)
                .FirstOrDefaultAsync(ct);
    }
}