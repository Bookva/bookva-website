﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Bookva.Business.Identity;
using Bookva.Entities;
using Bookva.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Drawing;
using Bookva.Business;
using Bookva.Business.ImageService;
using System.Net.Http;
using Bookva.Web.Mappers;
using Elmah;
using Microsoft.AspNet.Identity;

namespace Bookva.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private IAuthorService _authorService;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public AccountController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        /// <summary>
        /// /api/account/
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<UserViewModel> GetUserInfo()
        {
            var userId = User.Identity.GetUserId<int>();
            var userInfo = await UserManager.GetUserInfo(userId);
            return userInfo.ToViewModel();
        }

        /// <summary>
        /// /api/account/
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("createAuthor")]
        public IHttpActionResult CreateAuthor([FromBody]AuthorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = User.Identity.GetUserId<int>();
                    var author = AuthorMapper.ToDTO(model);
                    _authorService.CreateUserAuthor(author, userId);
                    return new OkResult(Request);
                }

                return new BadRequestResult(Request);
            }
            catch (Exception e)
            {
                ErrorLog.GetDefault(HttpContext.Current).Log(new Error(e));
                return BadRequest(e.Message);
            }
        }

        //
        // POST: /api/Account/Register
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Login, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //TODO: add email confirmation

                    return Ok();
                }
            }
            
            return new BadRequestResult(Request);
        }

        [HttpGet]
        [Route("authorize")]
        public IHttpActionResult Authorize()
        {
            var claims = new ClaimsPrincipal(User).Claims.ToList();
            var identity = new ClaimsIdentity(claims, "Bearer");
            AuthenticationManager.SignIn(identity);
            return  Ok();
        }

        [HttpGet]
        [Route("isAdmin")]
        public bool IsAdmin()
        {
            return User.IsInRole("Admin");
        }

        //
        // POST: /api/Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [Route("resetPassword")]
        public async Task<IHttpActionResult> ResetPassword([FromBody]ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid");
            }
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("Can't find this user");
            }
            var token = await UserManager.GeneratePasswordResetTokenAsync(user.Id); //TODO: find a way to send token via email
            var result = await UserManager.ResetPasswordAsync(user.Id, token, model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest("Error changing password");
        }

        //
        // POST: /api/Account/changePicture
        [HttpPost]
        [Route("changePicture")]
        public async Task<IHttpActionResult> ChangePicture()
        {
            var file = HttpContext.Current.Request.Files["image"];
            if (file == null)
            {
               return BadRequest("No image is attached");
            }
            var image = Image.FromStream(file.InputStream);           
            await UserManager.ChangePictureAsync(image, User.Identity.GetUserId<int>());

            return Ok();
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }
        
    }
}
