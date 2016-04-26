using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Filter;

namespace Bookva.Business.Filters
{
    static class QueryableExtensions
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> query, string sortField, SortOrder order)
        {
            try
            {
                return query.OrderBy(sortField + (order == SortOrder.Descending ? " descending" : ""));
            }
            catch (ParseException e)
            {
                
                throw new ArgumentException($"There is no sortable field named {sortField}.");
            }
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, PaginationOptions paginationOptions)
        {
            return query.Skip((paginationOptions.Page - 1) * paginationOptions.PageSize).Take(paginationOptions.PageSize);
        }
    }
}
