using System;
using System.Threading.Tasks;
using CarRental.Application.Common.Results;
using CarRental.Application.Features.Rentals.Commands.CreateRental;
using CarRental.Application.Features.Rentals.Commands.DeleteRental;
using CarRental.Application.Features.Rentals.Commands.UpdateRental;
using CarRental.Application.Features.Rentals.Queries.GetRentals;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Api.Rest.Controllers
{
    public class RentalsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IdResult> CreateRental([FromBody] CreateRentalCommand command)
            => await Mediator.Send(command);

        [HttpGet]
        public async Task<ListResult<GetRentalsResult>> GetRentals([FromQuery] GetRentalsQuery query)
            => await Mediator.Send(query);

        [HttpPut("{rentalId}")]
        public async Task UpdateRental([FromRoute] Guid rentalId, [FromBody] UpdateRentalCommand command)
        {
            command.RentalId = rentalId;
            await Mediator.Send(command);
        }

        [HttpDelete("{rentalId}")]
        public async Task DeleteRental([FromRoute] DeleteRentalCommand command)
            => await Mediator.Send(command);
    }
}