using System.Collections.Generic;

namespace CarRental.Application.Common.Results
{
    public record ListResult<T>(ICollection<T> Results, int TotalCount);
}