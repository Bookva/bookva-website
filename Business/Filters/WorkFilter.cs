using System;
using System.Linq;
using System.Linq.Expressions;
using Bookva.Entities;
using Bookva.BusinessEntities.Filter;
using Bookva.Common;

namespace Bookva.Business.Filters
{
    class WorkFilter : IFilter<Work, WorkFilterOptions>
    {
        public IQueryable<Work> Filter(IQueryable<Work> data, WorkFilterOptions filter)
        {
            if (filter.AuthorIds != null)
            {
                data = data.Where(w =>
                    w.Authors.Select(a => a.Id).Any(authorId =>
                        filter.AuthorIds.Contains(authorId))
                    );
            }

            if (filter.GenresIds != null)
            {
                data = data.Where(w =>
                    w.Genres.Select(g => g.Id).Any(genreId =>
                        filter.GenresIds.Contains(genreId))
                    );
            }

            if (filter.KeywordsIds != null)
            {
                data = data.Where(w =>
                    w.Keywords.Select(k => k.Id).Any(keywordId =>
                        filter.KeywordsIds.Contains(keywordId))
                    );
            }

            if (filter.Title != null)
            {
                data = data.Where(w => w.Title.Contains(filter.Title));
            }

            if (filter.YearCreated != null)
            {
                data = data.Where(w => w.YearCreated == filter.YearCreated);
            }

            return data;
        }

        public IQueryable<Work> Sort(IQueryable<Work> data, string fieldName, SortOrder order)
        {
            data = fieldName == null ?
                data.OrderBy(w => w.Title) :
                data.Sort(fieldName, order);

            return data;
        }
    }

}
