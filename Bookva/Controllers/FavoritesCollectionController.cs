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
    [RoutePrefix("api/favourites")]
    public class FavoritesCollectionController : ApiController
    {
        private readonly ICollectionsService collectionService;

        public FavoritesCollectionController(ICollectionsService collectionService)
        {
            this.collectionService = collectionService;
        }

        /// <summary>
        /// GET: /api/favourites
        /// </summary>
        /// <param name="options">Pagination options</param>
        /// <returns></returns>
        [Route("")]
        public IEnumerable<WorkPreviewViewModel> Get([FromUri]PaginationOptions options)
        {
            var userId = User.Identity.GetUserId<int>();
            var works = collectionService.GetFavouriteWorks(options, userId);
            
            return works.Select(WorksMapper.ToPreviewViewModel);
        }
        /// <summary>
        /// POST: /api/favourites/add/{workId}
        /// </summary>
        /// <param name="workId">Id of work</param>
        /// <returns></returns>
        [HttpPost]
        [Route("add/{workId}")]
        public IHttpActionResult Add([FromUri]int workId)
        {
            var userId = User.Identity.GetUserId<int>();
            collectionService.AddToFavourites(workId, userId);

            return Ok();
        }

        /// <summary>
        /// DELETE: /api/favourites/delete/{workid}
        /// </summary>
        /// <param name="workId">Id of work</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{workId}")]
        public IHttpActionResult Delete([FromUri]int workId)
        {
            var userId = User.Identity.GetUserId<int>();
            collectionService.DeleteFromFavourites(workId, userId);

            return Ok();
        }
    }
}
