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
using Microsoft.Ajax.Utilities;

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
            if (!genre.IsNullOrWhiteSpace() && genre.Length < 30)
            {
                _genreService.Create(new GenreModel { Value = genre });
                return Ok();
            }

            return BadRequest("Invalid genre");
        }
    }
}