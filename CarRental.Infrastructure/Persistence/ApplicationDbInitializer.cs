using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Persistence
{
    public class ApplicationDbInitializer : IApplicationDbInitializer
    {
        private readonly IApplicationDbContext _db;

        public ApplicationDbInitializer(IDbContextFactory<ApplicationDbContext> dbFactory)
            => _db = dbFactory.CreateDbContext();

        public async Task Migrate()
            => await _db.Database.MigrateAsync();

        public async Task Seed()
        {
            if (await _db.Cars.AnyAsync())
                return;

            _db.Cars.AddRange(GetSeedCars());
            await _db.SaveChangesAsync();
        }

        private ICollection<Car> GetSeedCars()
            => new List<Car>
            {
                new()
                {
                    Make = "Renault",
                    Model = "Megane",
                    ProductionYear = 2020,
                    RegistrationNumber = "ABC15126",
                    Rentals = new List<Rental>
                    {
                        new()
                        {
                            StartsAt = DateTimeOffset.Now.AddDays(-1),
                            EndsAt = DateTimeOffset.Now.AddDays(1),
                            RenterFullName = "John Doe",
                            Notes = "Please ensure the car is extra clean"
                        },
                        new()
                        {
                            StartsAt = DateTimeOffset.Now.AddDays(3),
                            EndsAt = DateTimeOffset.Now.AddDays(6),
                            RenterFullName = "Ann Doe"
                        }
                    }
                },
                new()
                {
                    Make = "Ford",
                    Model = "Focus",
                    ProductionYear = 2018,
                    RegistrationNumber = "EDF81823",
                    Rentals = new List<Rental>
                    {
                        new()
                        {
                            StartsAt = DateTimeOffset.Now.AddDays(-15),
                            EndsAt = DateTimeOffset.Now.AddDays(-10),
                            RenterFullName = "Jack Smith"
                        }
                    }
                },
                new()
                {
                    Make = "Opel",
                    Model = "Astra",
                    ProductionYear = 2019,
                    RegistrationNumber = "ASX31842",
                    Rentals = new List<Rental>
                    {
                        new()
                        {
                            StartsAt = DateTimeOffset.Now.AddDays(5),
                            EndsAt = DateTimeOffset.Now.AddDays(10),
                            RenterFullName = "Jack Black"
                        }
                    }
                }
            };
    }
}