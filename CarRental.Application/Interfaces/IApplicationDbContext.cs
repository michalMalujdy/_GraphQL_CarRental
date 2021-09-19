using System.Threading;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CarRental.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Car> Cars { get; }
        public DbSet<Rental> Rentals { get; }

        public DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}