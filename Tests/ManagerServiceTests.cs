using System;
using NUnit.Framework;
using Moq;
using AutoMapper;
using UoWandRepositories.Interfaces;
using BLL.Interfaces;
using BLL.Services;
using System.Collections.Generic;
using UoWandRepositories.Entities;
using BLL.DTO;
using Tests.Infrustructure;

namespace Tests
{
    [TestFixture]
    public class ManagerServiceTests
    {
        private IMapper _mapper;
        private Mock<IShopUnitOfWork> _db;
        private ManageService _service;

        public ManagerServiceTests()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<TestsMappingConfig>()).CreateMapper();
            _db = new Mock<IShopUnitOfWork>();
            _service = new ManageService(_db.Object, _mapper);

        }

        [Test]
        public void GetOrderTest()
        {
            _db.Setup(x => x.Orders.GetById(2)).Returns(GetOrder());

            var act = _service.GetOrder(2);
            var exp = GetOrder();

            Assert.NotNull(act);
            Assert.AreEqual(exp.OrderId, act.OrderId);
            Assert.AreEqual(exp.Price, act.Price);
            Assert.AreEqual(exp.Items.Count, act.Items.Count);
        }

        [Test]
        public void UpdateOrderTest()
        {
            _db.Setup(x => x.Orders.Edit(It.IsAny<OrderUoW>())).Verifiable();
            var order = _mapper.Map<OrderDTO>(GetOrder());

            var act = _service.UpdateOrder(order);

            Assert.IsTrue(act);
        }

        private OrderUoW GetOrder()
        {
            return new OrderUoW()
            {
                OrderId = 2,
                Time = DateTime.Now,
                Price = 0,
                State = StateUoW.Declined,
                Items = new List<ItemUoW>()
                {
                    GetItem()
                }
            };
        }

        private ItemUoW GetItem()
        {
            return new ItemUoW()
            {
                ItemId = 3,
                ItemName = "Phone",
                CategoryId = 2,
                Price = 100,
                Quantity = 1,
                Description = ")",
                Category = GetCategory()
            };
        }

        private CategoryUoW GetCategory()
        {
            return new CategoryUoW()
            {
                CategoryId = 1,
                CategoryName = "Phone"
            };
        }
    }
}
