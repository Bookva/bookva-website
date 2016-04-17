using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Keyword;
using Bookva.Entities;
using Bookva.Web.Models;

namespace Bookva.Business.Mappers
{
    static class GenreMapper
    {
        public static GenreModel ToDB(this GenreViewModel model)
        {
            return new GenreModel {Id = model.Id, Value = model.Value};
        }

        public static GenreViewModel ToViewModel(this GenreModel model)
        {
            return new GenreViewModel { Id = model.Id, Value = model.Value };
        }
    }
}
