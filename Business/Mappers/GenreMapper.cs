using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Keyword;
using Bookva.Entities;

namespace Bookva.Business.Mappers
{
    static class GenreMapper
    {
        public static Genre ToDB(this GenreModel model)
        {
            return new Genre { Id = model.Id ?? 0, Name = model.Value };
        }

        public static GenreModel ToModel(this Genre model)
        {
            return new GenreModel { Id = model.Id, Value = model.Name };
        }
    }
}
