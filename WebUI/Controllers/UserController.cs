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
    [Authorize]
    public class UserController : ApiController
    {
        IUserService _user;
        IMapper _mapper;
        IShoppingCart icart;
        ShoppingCartView _cartView;

        public UserController(IUserService user, IMapper mapper, IShoppingCart _icart)
        {
            _user = user;
            _mapper = mapper;
            icart = _icart;
            _cartView = new ShoppingCartView();
        }
        public UserController() { }

        [HttpPost]
        [Route("api/CartPanel/addItem")]
        public IHttpActionResult AddItem([FromBody]ItemView item, int quantity)
        {
            if (ModelState.IsValid)
            {
                var _item = _mapper.Map<ItemDTO>(item);
                bool result = _user.AddItem(_item, quantity, icart);

                if (result)
                    return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("api/CartPanel/removeItem")]
        public IHttpActionResult RemoveItem([FromBody]ItemView item)
        {
            var _item = _mapper.Map<ItemDTO>(item);
            bool result = _user.RemoveItem(_item, icart);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        [Route("api/CartPanel/composeOrder")]
        public IHttpActionResult ComposeCart()
        {
            var cart = _user.ComposeCart(icart);
            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpPost]
        [Route("api/OrderPanel/addOrder")]
        public IHttpActionResult MakeOrder()
        {
            var _order =_user.MakeOrder(icart);
            if (_order == null)
                return NotFound();

            OrderView _ordermap = _mapper.Map<OrderView>(_order);
            return Ok(_ordermap);
        }
    }
}
