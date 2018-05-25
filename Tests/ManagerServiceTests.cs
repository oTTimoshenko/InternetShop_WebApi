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
            //arrange
           // _db.Setup(x => x.Orders.GetById(2)).Returns();
        }
    }
}
