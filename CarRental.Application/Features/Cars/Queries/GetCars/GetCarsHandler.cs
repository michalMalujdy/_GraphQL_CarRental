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

namespace CarRental.Application.Features.Cars.Queries.GetCars
{
    public class GetCarsHandler : IRequestHandler<GetCarsQuery, ListResult<GetCarsResult>>
    {
        private readonly IApplicationDbContext _db;
        private readonly IMapper _mapper;

        public GetCarsHandler(IApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ListResult<GetCarsResult>> Handle(GetCarsQuery query, CancellationToken ct)
            => new (await GetCars(query, ct), await GetTotalCount(ct));

        private async Task<List<GetCarsResult>> GetCars(GetCarsQuery query, CancellationToken ct)
            => await _db.Cars
                .Where(r => !r.IsDeleted)
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ProjectTo<GetCarsResult>(_mapper.ConfigurationProvider)
                .ToListAsync(ct);

        private Task<int> GetTotalCount(CancellationToken ct)
            => _db.Cars
                .Where(r => !r.IsDeleted)
                .CountAsync(ct);
    }
}