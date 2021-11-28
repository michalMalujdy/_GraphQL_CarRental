using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Features.Cars.Commands.DeleteCar
{
    public class DeleteCarHandler : IRequestHandler<DeleteCarCommand>
    {
        private readonly IApplicationDbContext _db;

        public DeleteCarHandler(IApplicationDbContext db)
            => _db = db;

        public async Task<Unit> Handle(DeleteCarCommand command, CancellationToken ct)
        {
            var car = await GetCar(command, ct);
            car.IsDeleted = true;
            await _db.SaveChangesAsync(ct);

            return Unit.Value;
        }

        private async Task<Car> GetCar(DeleteCarCommand command, CancellationToken ct)
            => await _db.Cars
                .Where(c => c.Id == command.CarId)
                .FirstOrDefaultAsync(ct);
    }
}