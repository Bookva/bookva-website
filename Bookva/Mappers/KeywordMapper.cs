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
    static class KeywordMapper
    {
        public static KeywordModel ToDB(this KeywordViewModel model)
        {
            return new KeywordModel {Id = model.Id, Value = model.Value};
        }
        public static KeywordViewModel ToViewModel(this KeywordModel model)
        {
            return new KeywordViewModel { Id = model.Id, Value = model.Value };
        }
    }
}
