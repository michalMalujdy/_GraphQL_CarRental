using System.Threading.Tasks;
using CarRental.Application.Common;
using CarRental.Application.Features.Rentals.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Api.Rest.Controllers
{
    public class RentalsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IdResult> CreateRental([FromBody] CreateRentalCommand command)
            => await Mediator.Send(command);
    }
}