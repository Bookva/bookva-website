
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace Business
{
    public class WorksService :IWorksService
    {
        private readonly IUnitOfWork unitOfWork;
        public WorksService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public Work Get(int id)
        {
           return unitOfWork.WorkRepository.Get(id);
        }

        public IEnumerable<Work> GetAll()
        {
            return unitOfWork.WorkRepository.Get();
        }

        public IEnumerable<Work> Get(PaginationOptions options)
        {
            return unitOfWork.WorkRepository.Get().Skip((options.Page - 1)*options.PageSize).Take(options.PageSize);
        }

        public void Create(Work work)
        {
            unitOfWork.WorkRepository.Insert(work);
            unitOfWork.Save();
        }
    }
}
