using AutoMapper;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.Rentals.Queries.GetRentals
{
    public class GetRentalsMap : Profile
    {
        public GetRentalsMap()
        {
            CreateMap<Rental, GetRentalsResult>();
            CreateMap<Car, GetRentalsResult.CarResult>();
        }
    }
}