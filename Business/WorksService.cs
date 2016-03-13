using System.Collections.Generic;
using System.Linq;
using Bookva.Business.Mappers;
using Bookva.BusinessEntities.Work;
using Bookva.DAL;

namespace Bookva.Business
{
    public class WorksService :IWorksService
    {
        private readonly IUnitOfWork unitOfWork;
        public WorksService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public WorkReadModel Get(int id)
        {
           return unitOfWork.WorkRepository.Get(id).ToReadModel();
        }

        public IEnumerable<WorkPreviewModel> GetAll()
        {
            return unitOfWork.WorkRepository.Get().ToList().Select(WorksMapper.ToPreviewModel);
        }

        public IEnumerable<WorkPreviewModel> Get(PaginationOptions options)
        {
            return unitOfWork.WorkRepository.Get().OrderBy(w =>w.Id).Skip((options.Page - 1)*options.PageSize).Take(options.PageSize).ToList().Select(WorksMapper.ToPreviewModel);
        }

        public void Create(WorkWriteModel workDto)
        {
            var work = workDto.ToDB();
            foreach (var authorId in workDto.AuthorIds)
            {
                var author = unitOfWork.AuthorRepository.Get(authorId);
                work.Authors.Add(author);
            }
            //TODO: add keywords and genres
            unitOfWork.WorkRepository.Insert(work);
            unitOfWork.Save();
        }
    }
}
