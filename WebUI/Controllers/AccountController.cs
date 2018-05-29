using System.Collections.Generic;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;
using Owin;
using BLL.Interfaces;
using System.Web.Http;
using WebUI.Models;
using BLL.Entity.Account;
using BLL.Infrastructure;

namespace WebUI.Controllers
{
    public class AccountController : ApiController
    {
        private IAccountService AccountService
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<IAccountService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        [Route("api/Account/Login")]
        public IHttpActionResult Login([FromUri]LoginModel model)
        {
            SetInitialData();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim =  AccountService.Authenticate(userDto);
                if (claim == null)
                {
                    return Ok("Wrong login or password.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                }
                return Ok("Log in success.");
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("api/Account/Logout")]
        
        public IHttpActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return Ok();
        }

        [HttpGet]
        [Route("api/Account/Register")]
        public IHttpActionResult Register([FromUri]RegistrationModel model)
        {
            SetInitialData();
            OperationDetailsBLL operationDetails;
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    UserName = model.Name,
                    Name = model.Name,
                    Role = "user"
                };
                operationDetails = AccountService.Create(userDto);
                return Ok(operationDetails);
            }
            return BadRequest();
        }

        private void SetInitialData()
        {
             AccountService.SetInitialData(new UserDTO
             {
                Email = "antonsuhorada@mail.ru",
                UserName = "antonsuhorada@mail.ru",
                Password = "123456",
                Name = "Suhorada Anton",
                Address = "Nezhinskaya 29D, 713b",
                Role = "admin",
             }, new List<string> { "user", "admin", "manager" });

            AccountService.SetInitialData(new UserDTO
            {
                Email = "olexandrtimoshenko@mail.ru",
                UserName = "olexandrtimoshenko@mail.ru",
                Password = "123456",
                Name = "Timoshenko Olexandr",
                Address = "Nezhinskaya 29D, 713b",
                Role = "manager",
            }, new List<string> { "user", "admin", "manager"});
        }
    }
}
