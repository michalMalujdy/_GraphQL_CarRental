using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarRental.Application.Common.Results;
using CarRental.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Features.Rentals.Queries.GetRentals
{
    public class GetRentalsHandler : IRequestHandler<GetRentalsQuery, ListResult<GetRentalsResult>>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetRentalsHandler(IApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ListResult<GetRentalsResult>> Handle(GetRentalsQuery query, CancellationToken ct)
            => new(await GetRentals(query, ct), await GetTotalCount(ct));

        private async Task<List<GetRentalsResult>> GetRentals(GetRentalsQuery query, CancellationToken ct)
            => await _db.Rentals
                .Where(r => !r.IsDeleted)
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ProjectTo<GetRentalsResult>(_mapper.ConfigurationProvider)
                .ToListAsync(ct);

        private Task<int> GetTotalCount(CancellationToken ct)
            => _db.Rentals.CountAsync(ct);
    }
}