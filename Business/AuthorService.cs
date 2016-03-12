
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace Business
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork unitOfWork;
        public AuthorService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public Author Get(int id)
        {
           return unitOfWork.AuthorRepository.Get(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return unitOfWork.AuthorRepository.Get();
        }

        public IEnumerable<Author> Get(PaginationOptions options)
        {
            return unitOfWork.AuthorRepository.Get().OrderBy(a => a.Id).Skip((options.Page - 1)*options.PageSize).Take(options.PageSize);
        }

        public void Create(Author author)
        {
            unitOfWork.AuthorRepository.Insert(author);
            unitOfWork.Save();
        }
    }
}
