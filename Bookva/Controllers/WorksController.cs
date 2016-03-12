using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Bookva.Models;
using System.Web.Http.Results;
using Bookva.Mappers;
using Business;

namespace Bookva.Controllers
{
    [RoutePrefix("api/works")]
    public class WorksController : ApiController
    {
        private readonly IWorksService worksService;

        public WorksController(IWorksService worksService)
        {
            this.worksService = worksService;
        }

        [Route("all")]
        public IEnumerable<WorkViewModel> Get()
        {
            var list = worksService.GetAll();
            return list.Select(WorksMapper.ToViewModel);
        }
        [Route("")]
        public IEnumerable<WorkViewModel> Get([FromUri]PaginationOptions options)
        {
            var list = worksService.Get(options);
            return list.Select(WorksMapper.ToViewModel);
        }

        [Route("{id}")]
        public WorkViewModel Get(int id)
        {
            var work = worksService.Get(id);
            return WorksMapper.ToViewModel(work);
        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult Add(WorkViewModel model)
        {
            var work = WorksMapper.ToDTO(model);
            worksService.Create(work); 
            return new OkResult(Request);
        }
    }
}
