using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System.Web.Http;
using WebUI.Models;

namespace WebUI.Controllers
{

    public class UserController : ApiController
    {
        IUserService _user;
        IMapper _mapper;
        IShoppingCart icart;
        ShoppingCartView _cartView;
        IOutputService outputService;

        public UserController(IOutputService _outputService, IUserService user, IMapper mapper, IShoppingCart _icart)
        {
            outputService = _outputService;
            _user = user;
            _mapper = mapper;
            icart = _icart;
            _cartView = new ShoppingCartView();
        }
        public UserController() { }

        [HttpGet]
        [Route("api/CartPanel/addItem/{id}")]
        public IHttpActionResult AddItem(int id)
        {
            var item = outputService.GetItem(id);
            if (item != null)
            {
                bool result = _user.AddItem(item, 1, icart);

                if (result)
                    return Ok();
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("api/CartPanel/removeItem/{id}")]
        public IHttpActionResult RemoveItem(int id)
        {
            var item = outputService.GetItem(id);
            if (item != null)
            {
                bool result = _user.RemoveItem(item, icart);
                if (result)
                    return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("api/CartPanel/composeOrder")]
        public IHttpActionResult ComposeCart()
        {
            var cart = _user.ComposeCart(icart);
            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpGet]
        [Route("api/OrderPanel/addOrder")]
        public IHttpActionResult MakeOrder()
        {
            var _order = _user.MakeOrder(icart);
            if (_order == null)
                return NotFound();

            OrderView _ordermap = _mapper.Map<OrderView>(_order);
            return Ok(_ordermap);
        }
    }
}
