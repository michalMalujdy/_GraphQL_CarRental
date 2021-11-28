using System.Threading;
using System.Threading.Tasks;
using CarRental.Application.Common.Results;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;

namespace CarRental.Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarHandler : IRequestHandler<CreateCarCommand, IdResult>
    {
        private readonly IApplicationDbContext _db;

        public CreateCarHandler(IApplicationDbContext db)
            => _db = db;

        public async Task<IdResult> Handle(CreateCarCommand command, CancellationToken ct)
        {
            var car = new Car
            {
                Make = command.Make,
                Model = command.Model,
                RegistrationNumber = command.RegistrationNumber,
                ProductionYear = command.ProductionYear
            };

            _db.Cars.Add(car);
            await _db.SaveChangesAsync(ct);

            // Additional logic
                // Domain
                    // Car class could parse RegistrationNumber
                    // RegistrationNumber could be checked against allowed regions
                    // check if make and model exist in real world
                // Infrastructure
                    // Calling FinanceService for creating an invoice
                    // Calling CarMaintenanceService to schedule car check-ups
                    // Sending SMS to renter
                    // Sending Mail to renter

            return new IdResult(car.Id);
        }
    }
}