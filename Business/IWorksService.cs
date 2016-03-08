
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace Business
{
    public interface IWorksService
    {
        Work Get(int id);
        IEnumerable<Work> GetAll();
        IEnumerable<Work> Get(PaginationOptions options);
        void Create(Work work);

    }
}
