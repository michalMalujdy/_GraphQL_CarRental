using AutoMapper;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.Cars.Queries.GetCars
{
    public class GetCarsMap : Profile
    {
        public GetCarsMap()
        {
            CreateMap<Car, GetCarsResult>();
        }
    }
}