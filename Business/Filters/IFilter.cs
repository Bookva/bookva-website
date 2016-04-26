using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Filter;

namespace Bookva.Business.Filters
{
    interface IFilter<T, TFilterObject>
    {
        IQueryable<T> Filter(IQueryable<T> data, TFilterObject filter);
        IQueryable<T> Sort(IQueryable<T> data, string fieldname, SortOrder order);
    }
}
