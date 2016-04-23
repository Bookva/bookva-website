using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Bookva.Business;
using Bookva.BusinessEntities.Work;
using Bookva.Web.Mappers;
using Bookva.Web.Models;
using System.Web;
using System.Drawing;
using System.Threading.Tasks;
using Elmah;
using Microsoft.AspNet.Identity;

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
            try
            {
                int? userId = User.Identity.IsAuthenticated? (int?)User.Identity.GetUserId<int>(): null;
                var work = worksService.Get(id, userId);
                return Ok(WorksMapper.ToViewModel(work));
            }
            catch (KeyNotFoundException e)
            {
                ErrorLog.GetDefault(HttpContext.Current).Log(new Error(e));
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// POST: /api/works
        /// </summary>
        /// <param name="model">Work</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Create([FromBody]WorkEditViewModel model)
        {
            var work = WorksMapper.ToDTO(model);
            worksService.Create(work); 
            return new OkResult(Request);
        }

        /// <summary>
        /// PUT: /api/works
        /// </summary>
        /// <param name="model">Work</param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Edit([FromBody]WorkEditViewModel model)
        {
            var work = WorksMapper.ToDTO(model);
            worksService.Edit(work);
            return new OkResult(Request);
        }

        [HttpPost]
        [Route("api/works/changePicture/{id}")]
        public async Task<IHttpActionResult> ChangePicture([FromUri]int id)
        {
            var file = HttpContext.Current.Request.Files["image"];
            if (file == null)
            {
                return BadRequest("No image is attached");
            }
            var image = Image.FromStream(file.InputStream);

            await worksService.ChangePictureAsync(image, id);
            return new OkResult(Request);
        }

        [Authorize]
        [HttpPost]
        [Route("api/works/{id}/rate/{mark}")]
        public IHttpActionResult Rate([FromUri]int id, [FromUri]byte mark)
        {
            if (mark > 5) return BadRequest("Mark should be on range [0;5]");

            var userId = User.Identity.GetUserId<int>();
            worksService.Rate(id, userId, mark);
            return new OkResult(Request);
        }
    }
}
