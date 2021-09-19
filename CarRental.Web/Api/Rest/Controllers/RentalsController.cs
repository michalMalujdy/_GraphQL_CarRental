using System.Threading.Tasks;
using CarRental.Application.Features.Rentals.Commands;
using CarRental.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Api.Rest.Controllers
{
    public class RentalsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<Rental> CreateRental([FromBody] CreateRentalCommand command)
            => await Mediator.Send(command);
    }
}