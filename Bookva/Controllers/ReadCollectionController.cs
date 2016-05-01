using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bookva.Business;
using Bookva.BusinessEntities.Filter;
using Bookva.BusinessEntities.Work;
using Bookva.Web.Mappers;
using Bookva.Web.Models;
using Microsoft.AspNet.Identity;

namespace Bookva.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/readCollection")]
    public class ReadCollectionController : ApiController
    {
        private readonly ICollectionsService collectionService;

        public ReadCollectionController(ICollectionsService collectionService)
        {
            this.collectionService = collectionService;
        }

        /// <summary>
        /// GET: /api/readCollection
        /// </summary>
        /// <param name="options">Pagination options</param>
        /// <returns></returns>
        [Route("")]
        public IEnumerable<WorkPreviewViewModel> Get([FromUri] PaginationOptions options)
        {
            var userId = User.Identity.GetUserId<int>();
            var works = collectionService.GetReadWorks(options, userId);

            return works.Select(WorksMapper.ToPreviewViewModel);
        }

        /// <summary>
        /// POST: /api/readCollection/add/{workId}
        /// </summary>
        /// <param name="workId">Id of work</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add/{workId}")]
        public IHttpActionResult Add([FromUri] int workId)
        {
            var userId = User.Identity.GetUserId<int>();
            collectionService.AddToRead(workId, userId);

            return Ok();
        }

        /// <summary>
        /// POST: /api/readCollection/delete/{workId}
        /// </summary>
        /// <param name="workId">Id of work</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{workId}")]
        public IHttpActionResult Delete([FromUri] int workId)
        {
            var userId = User.Identity.GetUserId<int>();
            collectionService.DeleteFromRead(workId, userId);

            return Ok();
        }
    }
}
