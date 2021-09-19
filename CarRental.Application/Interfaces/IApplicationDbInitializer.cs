using System.Threading.Tasks;

namespace CarRental.Application.Interfaces
{
    public interface IApplicationDbInitializer
    {
        Task Migrate();
        Task Seed();
    }
}