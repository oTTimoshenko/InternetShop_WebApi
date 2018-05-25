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


    }
}
