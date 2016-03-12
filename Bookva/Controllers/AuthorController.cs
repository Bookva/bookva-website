using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Security;
using Bookva.Mappers;
using Bookva.Models;
using Business;
using Entities;

namespace Bookva.Controllers
{
    public class AuthorController : ApiController
    {
        private readonly IAuthorService authorService;
        
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        /// <summary>
        ///  GET: /api/author/
        /// </summary>
        /// <param name="options">Pagination options</param>
        /// <returns></returns>
        public IEnumerable<AuthorViewModel> Get([FromUri]PaginationOptions options)
        {
            IEnumerable<Author> authors;
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
        ///  GET: /api/author/{id}
        /// </summary>
        /// <param name="id">Author id</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var author = authorService.Get(id);
            if (author == null)
                return BadRequest("No author with such id");
            return Ok(AuthorMapper.ToViewModel(author));
        }
        
        /// <summary>
        /// POST: /api/author/
        /// </summary>
        /// <param name="model">Author</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Create(AuthorViewModel model)
        {
            var work = AuthorMapper.ToDTO(model);
            authorService.Create(work);
            return new OkResult(Request);
        }
    }
}
