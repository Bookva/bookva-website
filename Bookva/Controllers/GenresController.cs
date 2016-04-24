using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Bookva.Business;
using Bookva.Business.Mappers;
using Bookva.BusinessEntities.Keyword;
using Bookva.Web.Models;

namespace Bookva.Web.Controllers
{
    public class GenresController : ApiController
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        /// <summary>
        /// GET api/keywords/
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GenreViewModel> Get([FromUri]PaginationOptions options)
        {
            return _genreService.Get(options).Select(GenreMapper.ToViewModel);
        }

        /// <summary>
        /// POST api/keywords/
        /// </summary>
        /// <param name="genre"></param>
        public IHttpActionResult Post([FromBody]string genre)
        {
            if (ModelState.IsValid)
            {
                _genreService.Create(new GenreModel { Value = genre });
                return Ok();
            }

            return new BadRequestResult(Request);
        }
    }
}