using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookva.BusinessEntities.Keyword;
using Bookva.Entities;

namespace Bookva.Business.Mappers
{
    static class KeywordMapper
    {
        public static Keyword ToDB(this KeywordModel model)
        {
            return new Keyword { Id = model.Id ?? 0, Name = model.Value };
        }
        public static KeywordModel ToModel(this Keyword model)
        {
            return new KeywordModel { Id = model.Id, Value = model.Name };
        }
    }
}
