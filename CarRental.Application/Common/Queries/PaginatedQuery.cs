using CarRental.Application.Common.Results;
using MediatR;

namespace CarRental.Application.Common.Queries
{
    public class PaginatedQuery<T> : IRequest<ListResult<T>>
    {
        private int _page;
        private int _pageSize;

        private const int DefaultPage = 1;
        private const int DefaultPageSize = 5;

        public int Page
        {
            get => _page;
            set => _page = value < 1 ? DefaultPage : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value < 1 ? DefaultPageSize : value;
        }
    }
}