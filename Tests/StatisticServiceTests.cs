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
using BLL.Entity;

namespace Tests
{
    [TestFixture]
    public class StatisticServiceTests
    {
        private IMapper _mapper;
        private Mock<IShopUnitOfWork> _db;
        private StatisticService _service;

        public StatisticServiceTests()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<TestsMappingConfig>()).CreateMapper();
            _db = new Mock<IShopUnitOfWork>();
            _service = new StatisticService(_db.Object, _mapper);
        }

        [Test]
        public void GetAllOrders_Test()
        {
            _db.Setup(x => x.Orders.GetAll()).Returns(GetAllOrders());

            List<OrderDTO> act = _mapper.Map<List<OrderDTO>>(_service.getAllOrders());
            var exp = GetAllOrders();

            Assert.NotNull(act);
            Assert.AreEqual(exp[0].OrderId, act[0].OrderId);
            Assert.AreEqual(exp[0].Price, act[0].Price);
            Assert.AreEqual(exp[0].Items.Count, act[0].Items.Count);
            
        }

        private List<OrderUoW> GetAllOrders()
        {
            return new List<OrderUoW>()
            {
                new OrderUoW()
                {
                    OrderId = 2,
                    Time = DateTime.Now,
                    Price = 0,
                    State = StateUoW.Declined,
                    Items = new List<ItemUoW>()
                    {
                        GetItem()
                    }
                },
                new OrderUoW()
                {
                    OrderId = 2,
                    Time = DateTime.Now,
                    Price = 100,
                    Items = new List<ItemUoW>()
                    {
                        GetItem()
                    }
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

        [Test]
        public void GetAllItems_Test()
        {
            _db.Setup(x => x.Items.GetAll()).Returns(GetAllItems());

            List<ItemDTO> act = _mapper.Map<List<ItemDTO>>(_service.getAllItems());
            var exp = GetAllItems();

            Assert.NotNull(act);
            Assert.AreEqual(exp[0].ItemId, act[0].ItemId);
            Assert.AreEqual(exp[0].ItemName, act[0].ItemName);
            Assert.AreEqual(exp[1].Price, act[1].Price);
            Assert.AreEqual(exp[1].CategoryId, act[1].CategoryId);
        }

        private List<ItemUoW> GetAllItems()
        {
            return new List<ItemUoW>()
            {
                new ItemUoW()
                {
                    ItemId = 1,
                    ItemName = "IPhone 5",
                    CategoryId = 1,
                    Price = 500,
                    ItemCharacteristic = new ItemCharacteristicUoW()
                    {
                        ItemCharacteristicId = 1,
                        Camera = 8,
                        DisplayDiagonal = 4.8,
                        Memory = 64,
                        RAM = 4
                    }
                },
                new ItemUoW()
                {
                    ItemId = 2,
                    ItemName = "IPhone 6",
                    CategoryId = 1,
                    Price = 600,
                    ItemCharacteristic = new ItemCharacteristicUoW()
                    {
                        ItemCharacteristicId = 2,
                        Camera = 6,
                        DisplayDiagonal = 4.8,
                        Memory = 128,
                        RAM = 8
                    }
                },
                new ItemUoW()
                {
                    ItemId = 3,
                    ItemName = "IPhone 7",
                    CategoryId = 2,
                    Price = 700,
                    ItemCharacteristic = new ItemCharacteristicUoW()
                    {
                        ItemCharacteristicId = 3,
                        Camera = 2,
                        DisplayDiagonal = 2,
                        Memory = 256,
                        RAM = 12
                    }
                },
                 new ItemUoW()
                {
                    ItemId = 4,
                    ItemName = "IPhone 8",
                    CategoryId = 1,
                    Price = 800,
                    ItemCharacteristic = new ItemCharacteristicUoW()
                    {
                        ItemCharacteristicId = 1,
                        Camera = 8,
                        DisplayDiagonal = 4.8,
                        Memory = 64,
                        RAM = 4
                    }
                }
            };
        }

        //[Test]
        //public void getOverallStatistic()
        //{
        //    _db.Setup(x => x.Items.GetAll()).Returns(GetAllItems());
        //    _db.Setup(x => x.Orders.GetAll()).Returns(GetAllOrders());
        //    _db.Setup(x => x.Orders.)

        //    var exp = GetStatistic();

        //    var act = _service.getOverallStats();

        //    Assert.AreEqual(exp, act);
        //}

        private Statistic GetStatistic()
        {
            return new Statistic()
            {
                totalItems = 0,
                totalItemsSold = 9,
                totalRevenue = 0
            };
        }
    }
}
