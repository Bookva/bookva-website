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
    public class KeywordsController : ApiController
    {
        private readonly IKeywordService _keywordService;
        public KeywordsController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }
        /// <summary>
        /// GET api/keywords/
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeywordViewModel> Get([FromUri]PaginationOptions options)
        {
            return _keywordService.Get(options).Select(KeywordMapper.ToViewModel);
        }

        /// <summary>
        /// POST api/keywords/
        /// </summary>
        /// <param name="keyword"></param>
        public IHttpActionResult Post([FromBody]string keyword)
        {
            if (!keyword.IsNullOrWhiteSpace() && keyword.Length < 20)
            {
                _keywordService.Create(new KeywordModel {Value = keyword});
                return Ok();
            }

            return BadRequest("Invalid keyword");
        }
    }
}