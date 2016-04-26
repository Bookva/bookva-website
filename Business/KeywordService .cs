using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Bookva.Business.Filters;
using Bookva.Business.ImageService;
using Bookva.Business.Mappers;
using Bookva.BusinessEntities.Author;
using Bookva.BusinessEntities.Filter;
using Bookva.BusinessEntities.Keyword;
using Bookva.BusinessEntities.Work;
using Bookva.DAL;
using Bookva.Entities;

namespace Bookva.Business
{
    public class KeywordService : IKeywordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public KeywordService(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        public IEnumerable<KeywordModel> Get(PaginationOptions options)
        {
            return
                _unitOfWork.KeywordRepository.Get()
                    .OrderBy(k => k.Name)
                    .Paginate(options)
                    .Select(KeywordMapper.ToModel);
        }

        public Keyword Create(KeywordModel keywordModel)
        {
            var keyword = keywordModel.ToDB();
            _unitOfWork.KeywordRepository.Insert(keyword);
            _unitOfWork.Save();
            return keyword;
        }

        public IEnumerable<Keyword> Create(IEnumerable<KeywordModel> keywordModels)
        {
            var keywords = keywordModels.Select(KeywordMapper.ToDB).ToList();
            _unitOfWork.KeywordRepository.Insert(keywords);
            _unitOfWork.Save();
            return keywords;
        }
    }
}
