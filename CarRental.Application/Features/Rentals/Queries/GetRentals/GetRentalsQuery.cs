using CarRental.Application.Common.Results;
using MediatR;

namespace CarRental.Application.Features.Rentals.Queries.GetRentals
{
    public record GetRentalsQuery : IRequest<ListResult<GetRentalsResult>>
    {
        public int Page { get; }
        public int PageSize { get; }

        public GetRentalsQuery(int page, int pageSize)
        {
            if (page < 1)
                page = 1;

            Page = page;
            PageSize = pageSize;
        }
    }
}