using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Features.Cars.Commands.UpdateCar
{
    public class UpdateCarHandler : IRequestHandler<UpdateCarCommand, Unit>
    {
        private readonly IApplicationDbContext _db;

        public UpdateCarHandler(IApplicationDbContext db)
            => _db = db;

        public async Task<Unit> Handle(UpdateCarCommand command, CancellationToken ct)
        {
            var car = await GetCar(command, ct);
            MapToCar(car, command);
            await _db.SaveChangesAsync(ct);

            return Unit.Value;
        }

        private void MapToCar(Car car, UpdateCarCommand command)
        {
            car.Make = command.Make;
            car.Model = command.Model;
            car.RegistrationNumber = command.RegistrationNumber;
            car.ProductionYear = command.ProductionYear;
        }

        private async Task<Car> GetCar(UpdateCarCommand command, CancellationToken ct)
            => await _db.Cars
                .Where(c => c.Id == command.CarId)
                .FirstOrDefaultAsync(ct);
    }
}