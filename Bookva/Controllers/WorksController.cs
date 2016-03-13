using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Bookva.Business;
using Bookva.BusinessEntities.Work;
using Bookva.Web.Mappers;
using Bookva.Web.Models;

namespace Bookva.Web.Controllers
{
    public class WorksController : ApiController
    {
        private readonly IWorksService worksService;

        public WorksController(IWorksService worksService)
        {
            this.worksService = worksService;
        }

        /// <summary>
        /// GET: /api/works
        /// </summary>
        /// <param name="options">Pagination options</param>
        /// <returns></returns>
        public IEnumerable<WorkPreviewViewModel> Get([FromUri]PaginationOptions options)
        {
            IEnumerable<WorkPreviewModel> works;
            if (options == null)
            {
                works = worksService.GetAll();
            }
            else
            {
                works = worksService.Get(options);
            }
            return works.Select(WorksMapper.ToPreviewViewModel);
        }

        /// <summary>
        /// GET: /api/works/{id}
        /// </summary>
        /// <param name="id">WorkId</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var work = worksService.Get(id);
            if (work == null)
            {
                return NotFound();
            }

            return Ok(WorksMapper.ToViewModel(work));
        }

        /// <summary>
        /// POST: /api/works
        /// </summary>
        /// <param name="model">Work</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Create(WorkEditViewModel model)
        {
            var work = WorksMapper.ToDTO(model);
            worksService.Create(work); 
            return new OkResult(Request);
        }
    }
}
