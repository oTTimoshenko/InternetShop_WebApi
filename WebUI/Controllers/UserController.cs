using AutoMapper;
using BLL.DTO;
using BLL.Entity;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class UserController : ApiController
    {
        IUserService _user;
        IMapper _mapper;

        public UserController(IUserService user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }
        public UserController() { }

        [HttpPost]
        [Route("api/CartPanel/addItem")]
        public void AddItem([FromBody]ItemView item, int quantity)
        {
            var _item = _mapper.Map<ItemDTO>(item);
            _user.AddItem(_item, quantity);
        }

        [HttpDelete]
        [Route("api/CartPanel/removeItem")]
        public void RemoveItem([FromBody]ItemView item)
        {
            var _item = _mapper.Map<ItemDTO>(item);
            _user.RemoveItem(_item);
        }

        //[HttpPut]
        //[Route("api/CartPanel/composeOrder")]
        //public ShoppingCart ComposeCart()
        //{
        //    var cart = _user.ComposeCart();
            
        //    return cart;
        //}
    }
}
