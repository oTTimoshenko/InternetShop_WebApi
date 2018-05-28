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
using BLL.Models;

namespace Tests
{
    [TestFixture]
    public class OutputServiceTests
    {
        private IMapper mapper;
        private Mock<IShopUnitOfWork> db;
        private OutputService service;

        public OutputServiceTests()
        {
            mapper = new MapperConfiguration(cfg => cfg.AddProfile<TestsMappingConfig>()).CreateMapper();
            db = new Mock<IShopUnitOfWork>();
            service = new OutputService(db.Object, mapper);
        }

        [Test]
        public void GetAllItems_Test()
        {
            db.Setup(x => x.Items.GetAll()).Returns(GetAllItems());

            List<ItemDTO> act = mapper.Map<List<ItemDTO>>(service.GetAllItems());
            var exp = GetAllItems();

            Assert.NotNull(act);
            Assert.AreEqual(exp[0].ItemId, act[0].ItemId);
            Assert.AreEqual(exp[0].ItemName, act[0].ItemName);
            Assert.AreEqual(exp[1].Price, act[1].Price);
            Assert.AreEqual(exp[1].CategoryId, act[1].CategoryId);
        }

        [Test]
        public void Search_Test()
        {
            db.Setup(x => x.Items.GetAll()).Returns(GetAllItems());


            List<ItemDTO> act = mapper.Map<List<ItemDTO>>(service.Search("IPhone".ToLower()));
            var exp = GetItemsForSearch();

            Assert.NotNull(act);
            Assert.AreEqual(exp[0].ItemId, act[0].ItemId);
            Assert.AreEqual(exp[0].ItemName, act[0].ItemName);
            Assert.AreEqual(exp[0].Price, act[0].Price);
            Assert.AreEqual(exp[0].CategoryId, act[0].CategoryId);
        }

        [Test]
        public void FilterByCategory_Test()
        {
            db.Setup(x => x.Items.GetAll()).Returns(GetAllItems());


            List<ItemDTO> act = mapper.Map<List<ItemDTO>>(service.FilterByCategory(1));
            var exp = GetItemsWithCategory();

            Assert.NotNull(act);
            Assert.AreEqual(exp[0].ItemId, act[0].ItemId);
            Assert.AreEqual(exp[0].ItemName, act[0].ItemName);
            Assert.AreEqual(exp[1].Price, act[1].Price);
            Assert.AreEqual(exp[1].CategoryId, act[1].CategoryId);
        }

        [Test]
        public void GetItemsWithPagination_Test()
        {
            db.Setup(x => x.Items.GetAll()).Returns(GetAllItems());

            List<ItemDTO> act = mapper.Map<List<ItemDTO>>(service.GetItemsWithPagination(1, 2));
            var exp = GetItemsWithPagination();

            Assert.NotNull(act);
            Assert.AreEqual(2, act.Count);
            Assert.AreEqual(exp[0].ItemId, act[0].ItemId);
            Assert.AreEqual(exp[0].ItemName, act[0].ItemName);
            Assert.AreEqual(exp[1].Price, act[1].Price);
            Assert.AreEqual(exp[1].CategoryId, act[1].CategoryId);
        }

        [Test]
        public void SortByName_Test()
        {
            db.Setup(x => x.Items.GetAll()).Returns(GetAllItems());

            List<ItemDTO> act = mapper.Map<List<ItemDTO>>(service.SortBy(BLLSortCriteria.NAME));
            var exp = GetAllItems();

            Assert.NotNull(act);
            Assert.AreEqual(4, act.Count);
            Assert.AreEqual(exp[0].ItemId, act[0].ItemId);
            Assert.AreEqual(exp[0].ItemName, act[0].ItemName);
            Assert.AreEqual(exp[1].Price, act[1].Price);
            Assert.AreEqual(exp[1].CategoryId, act[1].CategoryId);
        }

        [Test]
        public void SortByDescendingByName_Test()
        {
            db.Setup(x => x.Items.GetAll()).Returns(GetAllItems());

            List<ItemDTO> act = mapper.Map<List<ItemDTO>>(service.SortByDescending(BLLSortCriteria.NAME));
            var exp = GetAllItemsReverse();

            Assert.NotNull(act);
            Assert.AreEqual(4, act.Count);
            Assert.AreEqual(exp[0].ItemId, act[0].ItemId);
            Assert.AreEqual(exp[0].ItemName, act[0].ItemName);
            Assert.AreEqual(exp[1].Price, act[1].Price);
            Assert.AreEqual(exp[1].CategoryId, act[1].CategoryId);
        }

        [Test]
        public void SortByPrice_Test()
        {
            db.Setup(x => x.Items.GetAll()).Returns(GetAllItems());

            List<ItemDTO> act = mapper.Map<List<ItemDTO>>(service.SortBy(BLLSortCriteria.PRICE));
            var exp = GetAllItems();

            Assert.NotNull(act);
            Assert.AreEqual(4, act.Count);
            Assert.AreEqual(exp[0].ItemId, act[0].ItemId);
            Assert.AreEqual(exp[0].ItemName, act[0].ItemName);
            Assert.AreEqual(exp[1].Price, act[1].Price);
            Assert.AreEqual(exp[1].CategoryId, act[1].CategoryId);
        }

        [Test]
        public void SortByDescendingByPrice_Test()
        {
            db.Setup(x => x.Items.GetAll()).Returns(GetAllItems());

            List<ItemDTO> act = mapper.Map<List<ItemDTO>>(service.SortByDescending(BLLSortCriteria.PRICE));
            var exp = GetAllItemsReverse();

            Assert.NotNull(act);
            Assert.AreEqual(4, act.Count);
            Assert.AreEqual(exp[0].ItemId, act[0].ItemId);
            Assert.AreEqual(exp[0].ItemName, act[0].ItemName);
            Assert.AreEqual(exp[1].Price, act[1].Price);
            Assert.AreEqual(exp[1].CategoryId, act[1].CategoryId);
        }

        [Test]
        public void FilterByCriteria_Test()
        {
            db.Setup(x => x.Items.GetAll()).Returns(GetAllItems());
            db.Setup(x => x.ItemCharacteristics.GetById(1)).Returns(GetAllItemCharacteristic()[0]);
            db.Setup(x => x.ItemCharacteristics.GetById(2)).Returns(GetAllItemCharacteristic()[1]);
            db.Setup(x => x.ItemCharacteristics.GetById(3)).Returns(GetAllItemCharacteristic()[2]);
            db.Setup(x => x.ItemCharacteristics.GetById(4)).Returns(GetAllItemCharacteristic()[3]);


            List<ItemDTO> act = mapper.Map<List<ItemDTO>>(service.FilterByCriteria(GetFilterCriteries()));
            var exp = GetItemCharacteristicWithCriteria();

            Assert.NotNull(act);
            Assert.AreEqual(2, act.Count);
            Assert.AreEqual(exp[0].Camera, act[0].ItemCharacteristic.Camera);
            Assert.AreEqual(exp[0].RAM, act[0].ItemCharacteristic.RAM);
            Assert.AreEqual(exp[1].Memory, act[1].ItemCharacteristic.Memory);
            Assert.AreEqual(exp[1].DisplayDiagonal, act[1].ItemCharacteristic.DisplayDiagonal);
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

        private List<ItemUoW> GetAllItemsReverse()
        {
            return new List<ItemUoW>()
            {
                new ItemUoW()
                {
                    ItemId = 4,
                    ItemName = "IPhone 8",
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
                }
            };
        }

        private List<ItemUoW> GetItemsForSearch()
        {
            return new List<ItemUoW>()
            {
                new ItemUoW()
                {
                    ItemId = 1,
                    ItemName = "IPhone 5",
                    CategoryId = 1,
                    Price = 500
                },
            };
        }

        private List<ItemUoW> GetItemsWithCategory()
        {
            return new List<ItemUoW>()
            {
                new ItemUoW()
                {
                    ItemId = 1,
                    ItemName = "IPhone 5",
                    CategoryId = 1,
                    Price = 500
                },
                new ItemUoW()
                {
                    ItemId = 2,
                    ItemName = "IPhone 6",
                    CategoryId = 1,
                    Price = 600
                },
            };
        }

        private List<ItemUoW> GetItemsWithPagination()
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
                }
            };
        }

        private List<ItemCharacteristicUoW> GetAllItemCharacteristic()
        {
            return new List<ItemCharacteristicUoW>()
            {
                 new ItemCharacteristicUoW()
                    {
                        ItemCharacteristicId = 1,
                        Camera = 8,
                        DisplayDiagonal = 4.8,
                        Memory = 64,
                        RAM = 4
                    },
                new ItemCharacteristicUoW()
                    {
                        ItemCharacteristicId = 2,
                        Camera = 6,
                        DisplayDiagonal = 4.8,
                        Memory = 128,
                        RAM = 8
                    },
                 new ItemCharacteristicUoW()
                    {
                        ItemCharacteristicId = 3,
                        Camera = 2,
                        DisplayDiagonal = 2,
                        Memory = 256,
                        RAM = 12
                    },
                 new ItemCharacteristicUoW()
                    {
                        ItemCharacteristicId = 4,
                        Camera = 8,
                        DisplayDiagonal = 4.8,
                        Memory = 64,
                        RAM = 4
                    }
            };
        }

        private FilterCriteries GetFilterCriteries()
        {
            return new FilterCriteries()
            {
                Camera = new double[] { 8 },
                DisplayDiagonal = new double[] { 4.8 },
                RAM = new int[] { 4 },
                MemorySize = new int[] { 64 },
            };
        }

        private List<ItemCharacteristicUoW> GetItemCharacteristicWithCriteria()
        {
            return new List<ItemCharacteristicUoW>()
            {
                new ItemCharacteristicUoW()
                    {
                        ItemCharacteristicId = 1,
                        Camera = 8,
                        DisplayDiagonal = 4.8,
                        Memory = 64,
                        RAM = 4
                    },
                new ItemCharacteristicUoW()
                    {
                        ItemCharacteristicId = 4,
                        Camera = 8,
                        DisplayDiagonal = 4.8,
                        Memory = 64,
                        RAM = 4
                    }
            };
        }
    }
}
