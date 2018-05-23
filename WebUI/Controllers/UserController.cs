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
        ShoppingCartView _cartView;

        public UserController(IUserService user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
            _cartView = new ShoppingCartView();
        }
        public UserController() { }

        [HttpPost]
        [Route("api/CartPanel/addItem")]
        public void AddItem([FromBody]ItemView item, int quantity)
        {
            var _item = _mapper.Map<ItemDTO>(item);
            ShoppingCart cartView = _mapper.Map<ShoppingCart>(_cartView);
            _user.AddItem(_item, quantity, cartView);
        }

        [HttpDelete]
        [Route("api/CartPanel/removeItem")]
        public void RemoveItem([FromBody]ItemView item)
        {
            var _item = _mapper.Map<ItemDTO>(item);
            ShoppingCart cartView = _mapper.Map<ShoppingCart>(_cartView);
            _user.RemoveItem(_item, cartView);
        }

        [HttpPut]
        [Route("api/CartPanel/composeOrder")]
        public ShoppingCartView ComposeCart()
        {
            ShoppingCart cartView = _mapper.Map<ShoppingCart>(_cartView);
            cartView.lines = _mapper.Map<List<ShoppingCartLine>>(_cartView.lines);
            var cart = _user.ComposeCart(cartView);
            ShoppingCartView _cart = _mapper.Map<ShoppingCartView>(cart);
            return _cart;
        }

        [HttpPost]
        [Route("api/OrderPanel/addOrder")]
        public OrderView MakeOrder([FromBody]ShoppingCartView order)
        {
            var _cart = _mapper.Map<ShoppingCart>(order);
            var _order =_user.MakeOrder(_cart);
            OrderView _ordermap = _mapper.Map<OrderView>(_order);
            return _ordermap;
        }

    }
}
