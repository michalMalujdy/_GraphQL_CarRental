using System;
using System.Threading.Tasks;
using CarRental.Application.Common.Results;
using CarRental.Application.Features.Cars.Commands.CreateCar;
using CarRental.Application.Features.Cars.Commands.DeleteCar;
using CarRental.Application.Features.Cars.Commands.UpdateCar;
using CarRental.Application.Features.Cars.Queries.GetCars;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Api.Rest.Controllers
{
    public class CarsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IdResult> CreateCar(CreateCarCommand command)
            => await Mediator.Send(command);

        [HttpGet]
        public async Task<ListResult<GetCarsResult>> GetCars([FromQuery] GetCarsQuery query)
            => await Mediator.Send(query);

        [HttpPut("{carId}")]
        public async Task UpdateCar([FromRoute] Guid carId, [FromBody] UpdateCarCommand command)
        {
            command.CarId = carId;
            await Mediator.Send(command);
        }

        [HttpDelete("{carId}")]
        public async Task DeleteCar([FromRoute] DeleteCarCommand command)
            => await Mediator.Send(command);
    }
}