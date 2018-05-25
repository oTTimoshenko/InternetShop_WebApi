using System;
using NUnit.Framework;
using Moq;
using AutoMapper;
using UoWandRepositories.Interfaces;
using BLL.Interfaces;
using Tests.Infrustructure;
using BLL.Services;
using System.Collections.Generic;
using UoWandRepositories.Entities;
using BLL.DTO;
using BLL.Entity;

namespace Tests
{
    public class UserServiceTests
    {
        private IMapper _mapper;
        private Mock<IShopUnitOfWork> _db;
        private UserService _service;

        public UserServiceTests()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<TestsMappingConfig>()).CreateMapper();
            _db = new Mock<IShopUnitOfWork>();
            _service = new UserService(_db.Object, _mapper);
        }

        [Test]
        public void AddItemToCartTest()
        {
            _db.Setup(x => x.Items.Add(It.IsAny<ItemUoW>())).Verifiable();

            var itemDTO = _mapper.Map<ItemDTO>(GetItem());
            bool act = _service.AddItem(itemDTO, 2, GetCart());

            Assert.IsTrue(act);
        }

        [Test]
        public void RemoveItemFromCartTest()
        {
            bool act = _service.RemoveItem(GetItem() ,GetCart());

            Assert.IsTrue(act);
        }

        public ShoppingCart GetCart()
        {
            return new ShoppingCart()
            {
                lines = new List<ShoppingCartLine>()
                {
                    new ShoppingCartLine()
                    {
                        Item = new ItemDTO
                        {
                            ItemId = 1,
                            ItemName = "IPhone 5",
                            CategoryId = 1,
                            Price = 500,
                        },
                        Quantity = 1,
                        ShoppingCartId = 0
                    }
                },
                overallPrice = 0
            };

        }

        public ItemDTO GetItem()
        {
            return new ItemDTO
            {
                ItemId = 1,
                ItemName = "IPhone 5",
                CategoryId = 1,
                Price = 500,
            };
        }
       
        [Test]
        public void ClearCartTest()
        {
            bool act = _service.Clear(GetCart());

            Assert.IsTrue(act);
        }

        //[Test]
        //public void ComposeCartTest()
        //{
        //    _db.Setup(x => x.Items.Add(It.IsAny<ItemUoW>())).Verifiable();

        //    var act = _service.ComposeCart(GetCart());

        //    var exp = GetCart();

        //    Assert.AreEqual(act, exp);
        //}

        //[Test]
        //public void MakeOrderTest()
        //{

        //}
    }

}
