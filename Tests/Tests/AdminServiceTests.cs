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


namespace Tests
{
    [TestFixture]
    public class AdminServiceTests
    {
        private IMapper mapper;
        private Mock<IShopUnitOfWork> db;
        private AdminService admin;

        public AdminServiceTests()
        {
            mapper = new MapperConfiguration(cfg => cfg.AddProfile<TestsMappingConfig>()).CreateMapper();
            db = new Mock<IShopUnitOfWork>();
            admin = new AdminService(db.Object, mapper);
        }

        //GET
        [Test]
        public void GetCategory_Test()
        {
            //Arrenge
            db.Setup(x => x.Categories.GetById(2)).Returns(GetCategory());

            //Act
            var act = admin.GetCategory(2);

            var expected = GetCategory();

            Assert.AreEqual(expected.CategoryId, act.CategoryId);
            Assert.AreEqual(expected.CategoryName, act.CategoryName);
        }
        [Test]
        public void GetItem_Test()
        {
            //arrenge
            db.Setup(x => x.Items.GetById(3)).Returns(GetItem());

            var act = admin.GetItem(3);

            var exp = GetItem();

            Assert.NotNull(act);
            Assert.AreEqual(exp.ItemId, act.ItemId);
            Assert.AreEqual(exp.ItemName, act.ItemName);
            Assert.AreEqual(exp.Price, act.Price);
            Assert.AreEqual(exp.Quantity, act.Quantity);
            Assert.AreEqual(exp.CategoryId, act.CategoryId);
            Assert.AreEqual(exp.Category.CategoryName, act.Category.CategoryName);
            Assert.AreEqual(exp.Description, act.Description);
        }
        [Test]
        public void GetItemCharacteristic_Test()
        {
            db.Setup(x => x.ItemCharacteristics.GetById(3)).Returns(GetItemCharacteristic());

            var act = admin.GetItemCharacteristics(3);

            var exp = GetItemCharacteristic();

            Assert.NotNull(act);
            Assert.AreEqual(exp.ItemCharacteristicId, act.ItemCharacteristicId);
            Assert.AreEqual(exp.Camera, act.Camera);
            Assert.AreEqual(exp.DisplayDiagonal, act.DisplayDiagonal);
            Assert.AreEqual(exp.Memory, act.Memory);
            Assert.AreEqual(exp.RAM, act.RAM);
        }
        [Test]
        public void GetOrder_Test()
        {
            db.Setup(x => x.Orders.GetById(3)).Returns(GetOrder());

            var act = admin.GetOrder(3);

            var exp = GetOrder();
            
            Assert.NotNull(act);
            Assert.AreEqual(exp.OrderId, act.OrderId);
            Assert.AreEqual(exp.Price, act.Price);
            Assert.AreEqual(exp.Items.Count, act.Items.Count);
        }
        //GET

        //ADD
        [Test]
        public void AddCategory_Test()
        {
            db.Setup(x => x.Categories.Add(It.IsAny<CategoryUoW>())).Verifiable();

            var categoryDTO = mapper.Map<CategoryDTO>(GetCategory());
            bool act = admin.AddCategory(categoryDTO);

            Assert.IsTrue(act);
        }
        [Test]
        public void AddItem_Test()
        {
            db.Setup(x => x.Items.Add(It.IsAny<ItemUoW>())).Verifiable();

            var itemDTO = mapper.Map<ItemDTO>(GetItem());
            bool act = admin.AddItem(itemDTO);

            Assert.IsTrue(act);
        }
        [Test]
        public void AddItemCharacteristic_Test()
        {
            db.Setup(x => x.ItemCharacteristics.Add(It.IsAny<ItemCharacteristicUoW>())).Verifiable();

            var itemCharacteristicsDTO = mapper.Map<ItemCharacteristicsDTO>(GetItemCharacteristic());
            bool act = admin.AddItemCharacteristic(itemCharacteristicsDTO);
            
            Assert.IsTrue(act);
        }
        //ADD

        //UPDATE
        [Test]
        public void UpdateCategory_Test()
        {
            db.Setup(x => x.Categories.Edit(It.IsAny<CategoryUoW>())).Verifiable();
            var category = mapper.Map<CategoryDTO>(GetCategory());

            var act = admin.UpdateCategory(category);

            Assert.IsTrue(act);
        }
        [Test]
        public void UpdateItem_Test()
        {
            db.Setup(x => x.Items.Edit(It.IsAny<ItemUoW>())).Verifiable();
            var item = mapper.Map<ItemDTO>(GetItem());

            var act = admin.UpdateItem(item);

            Assert.IsTrue(act);
        }
        [Test]
        public void UpdateItemCharacteristic_Test()
        {
            db.Setup(x => x.ItemCharacteristics.Edit(It.IsAny<ItemCharacteristicUoW>())).Verifiable();
            var itemsCharacteristic = mapper.Map<ItemCharacteristicsDTO>(GetItemCharacteristic());

            var act = admin.UpdateItemCharacteristic(itemsCharacteristic);

            Assert.IsTrue(act);
        }
        //UPDATE

        //REMOVE
        [Test]
        public void RemoveCategory_Test()
        {
            db.Setup(x => x.Categories.DeleteById(It.IsAny<int>())).Verifiable();

            var act = admin.RemoveCategory(3);

            Assert.IsTrue(act);
        }
        [Test]
        public void RemoveItem_Test()
        {
            db.Setup(x => x.Items.DeleteById(It.IsAny<int>())).Verifiable();

            var act = admin.RemoveItem(3);

            Assert.IsTrue(act);
        }
        [Test]
        public void RemoveItemCharacteristic_Test()
        {
            db.Setup(x => x.ItemCharacteristics.DeleteById(It.IsAny<int>())).Verifiable();

            var act = admin.RemoveItemCharacteristic(3);

            Assert.IsTrue(act);
        }
        //REMOVE

        private CategoryUoW GetCategory()
        {
            return new CategoryUoW()
            {
                CategoryId = 2,
                CategoryName = "Smartphones"
            };
        }

        private ItemUoW GetItem()
        {
            return new ItemUoW()
            {
                ItemId = 3,
                ItemName = "IPhone",
                CategoryId = 2,
                Price = 350,
                Quantity = 0,
                Description = "Nice smartphone",
                Category = GetCategory()
            };
        }

        private ItemCharacteristicUoW GetItemCharacteristic()
        {
            return new ItemCharacteristicUoW()
            {
                ItemCharacteristicId = 3,
                Camera = 12,
                DisplayDiagonal = 4.8,
                Memory = 64,
                RAM = 2
            };
        }

        private OrderUoW GetOrder()
        {
            return new OrderUoW()
            {
                OrderId = 3,
                Price = 400,
                State = StateUoW.Confirmed,
                Time = DateTime.Now,
                Items = new List<ItemUoW>()
                {
                    GetItem()
                }
            };
        }
    }
}
