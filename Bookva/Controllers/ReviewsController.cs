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
using Microsoft.AspNet.Identity;

namespace Bookva.Web.Controllers
{
    public class ReviewsController : ApiController
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this._reviewService = reviewService;
        }

        /// <summary>
        /// POST: /api/reviews/
        /// </summary>
        /// <param name="model">Review</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IHttpActionResult Create([FromBody]ReviewEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId<int>();
                if (userId > 0)
                {
                    var review = ReviewMapper.ToDTO(model, userId);
                    _reviewService.Create(review);
                    return new OkResult(Request);
                }
                else
                {
                    ErrorLog.GetDefault(HttpContext.Current).Log(new Error(new KeyNotFoundException("No user id is provided.")));
                    return InternalServerError();
                }
            }

            return new BadRequestResult(Request);
        }

        /// <summary>
        /// PUT: /api/reviews/
        /// </summary>
        /// <param name="model">Review</param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        public IHttpActionResult Edit([FromBody]ReviewEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId<int>();
                if (userId > 0)
                {
                    var review = ReviewMapper.ToDTO(model, userId);
                    _reviewService.Edit(review);
                    return new OkResult(Request);
                }
                else
                {
                    ErrorLog.GetDefault(HttpContext.Current).Log(new Error(new KeyNotFoundException("No user id is provided.")));
                    return InternalServerError();
                }
            }

            return new BadRequestResult(Request);
        }

        /// <summary>
        /// DELETE: /api/reviews/
        /// </summary>
        /// <param name="id">Review id</param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _reviewService.Delete(id);
            return new OkResult(Request);
        }
    }
}
