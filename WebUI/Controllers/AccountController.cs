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
        public string Login([FromUri]LoginModel model)
        {
            SetInitialData();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim =  AccountService.Authenticate(userDto);
                if (claim == null)
                {
                    return "Неверный логин или пароль.";
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                }
                return "Вход выполнен успешно.";
            }
            return null;
        }

        [HttpPost]
        [Route("api/Account/Logout")]
        public void Logout()
        {
            AuthenticationManager.SignOut();
        }

        [HttpGet]
        [Route("api/Account/Register")]
        public OperationDetailsBLL Register([FromUri]RegistrationModel model)
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
                return operationDetails;
            }
            return null;
        }

        private void SetInitialData()
        {
             AccountService.SetInitialData(new UserDTO
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Семен Семенович Горбунков",
                Address = "ул. Спортивная, д.30, кв.75",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
    }
}
