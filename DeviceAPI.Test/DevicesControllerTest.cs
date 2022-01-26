using DeviceAPI.Controllers;
using DeviceAPI.Data;
using DeviceAPI.Data.Models;
using DeviceAPI.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DeviceAPI.Test
{
    public class DevicesControllerTest
    {
        IDeviceService _service;
        protected ApplicationContext _dbContext;


        public DevicesControllerTest()
        {
            var options = CreateNewContextOptions();
            _dbContext = new ApplicationContext(options);

            _service = new DeviceService(_dbContext);

        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            _dbContext.Add(new Device {
                Name = "Device 1",
                Id = 1,
                Temperature = 10.0f,
                Status = Data.Enums.DeviceStatus.Available,
                Type = Data.Enums.DeviceType.Mobile
            });
            _dbContext.SaveChanges();

            //Act
            var devices = _service.GetAll();

            //Assert
            Assert.Single(devices);
        }


        protected static DbContextOptions<ApplicationContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            builder.UseInMemoryDatabase("DeviceDb")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

    }
}
