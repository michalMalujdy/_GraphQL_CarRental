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
        public async Task<ListResult<GetRentalsResult>> GetRentals([FromBody] GetRentalsQuery query)
            => await Mediator.Send(query);

        [HttpPut]
        public async Task UpdateRental([FromBody] UpdateRentalCommand command)
            => await Mediator.Send(command);

        [HttpDelete]
        public async Task DeleteRental([FromBody] DeleteRentalCommand command)
            => await Mediator.Send(command);
    }
}