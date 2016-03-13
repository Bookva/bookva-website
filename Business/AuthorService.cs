using System.Collections.Generic;
using System.Linq;
using Bookva.Business.Mappers;
using Bookva.BusinessEntities.Author;
using Bookva.DAL;

namespace Bookva.Business
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork unitOfWork;
        public AuthorService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public AuthorReadModel Get(int id)
        {
           return unitOfWork.AuthorRepository.Get(id).ToReadModel();
        }

        public IEnumerable<AuthorReadModel> GetAll()
        {
            return unitOfWork.AuthorRepository.Get().ToList().Select(AuthorMapper.ToReadModel);
        }

        public IEnumerable<AuthorReadModel> Get(PaginationOptions options)
        {
            return unitOfWork.AuthorRepository.Get().OrderBy(a => a.Id).Skip((options.Page - 1)*options.PageSize).Take(options.PageSize).ToList().Select(AuthorMapper.ToReadModel);
        }

        public void Create(AuthorWriteModel author)
        {
            unitOfWork.AuthorRepository.Insert(author.ToDb());
            unitOfWork.Save();
        }
    }
}
