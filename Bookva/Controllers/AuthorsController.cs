using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Bookva.Business;
using Bookva.BusinessEntities.Author;
using Bookva.Web.Mappers;
using Bookva.Web.Models;
using Elmah;
using Elmah.Contrib.WebApi;

namespace Bookva.Web.Controllers
{
    public class AuthorsController : ApiController
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        /// <summary>
        ///  GET: /api/authors/
        /// </summary>
        /// <param name="options">Pagination options</param>
        /// <returns></returns>
        public IEnumerable<AuthorViewModel> Get([FromUri]PaginationOptions options)
        {
            IEnumerable<AuthorReadModel> authors;
            if (options == null)
            {
                authors = authorService.GetAll();
            }
            else
            {
                authors = authorService.Get(options);
            }

            return authors.Select(AuthorMapper.ToViewModel);
        }

        /// <summary>
        ///  GET: /api/authors/{id}
        /// </summary>
        /// <param name="id">Author id</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            try
            {
                var author = authorService.Get(id);
                return Ok(AuthorMapper.ToViewModel(author));
            }
            catch (KeyNotFoundException e)
            {
                ErrorLog.GetDefault(HttpContext.Current).Log(new Error(e));
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// POST: /api/authors/
        /// </summary>
        /// <param name="model">Author</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Create([FromBody]AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = AuthorMapper.ToDTO(model);
                authorService.Create(author);
                return new OkResult(Request);
            }

            return new BadRequestResult(Request);
        }

        /// <summary>
        /// PUT: /api/authors/
        /// </summary>
        /// <param name="model">Author</param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult Edit([FromBody]AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = AuthorMapper.ToDTO(model);
                authorService.Edit(author);
                return new OkResult(Request);
            }

            return new BadRequestResult(Request);
        }

        [HttpPost]
        [Route("api/author/changePicture/{id}")]
        public async Task<IHttpActionResult> ChangePicture([FromBody]int id)
        {
            var file = HttpContext.Current.Request.Files["image"];
            if (file == null)
            {
                return BadRequest("No image is attached");
            }
            var image = Image.FromStream(file.InputStream);

            await authorService.ChangePictureAsync(image, id);
            return new OkResult(Request);
        }
    }
}
