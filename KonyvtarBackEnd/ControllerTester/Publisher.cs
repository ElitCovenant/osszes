using KonyvtarBackEnd.Controllers;
using KonyvtarBackEnd.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerTester
{
    public class Publisher
    {
        private readonly PublisherController controller = new PublisherController();

        [Fact]
        public async Task GetAll()
        {
            var result = await controller.GetAll();
            Assert.IsType<ActionResult<PublisherDto>>(result);
        }

        [Fact]
        public async Task Get()
        {
            var result = await controller.Get(1);
            Assert.IsType<ActionResult<PublisherDto>>(result);
        }

        [Fact]
        public async Task Post()
        {
            CreateOrModifyPublisherDto dto = new CreateOrModifyPublisherDto(1, "Test");
            var result = await controller.Post(dto);
            Assert.IsType<ActionResult<PublisherDto>>(result);
        }

        [Fact]
        public async Task Put()
        {
            CreateOrModifyPublisherDto dto = new CreateOrModifyPublisherDto(1, "Test");
            var result = await controller.Post(dto);
            Assert.IsType<ActionResult<PublisherDto>>(result);
        }

        [Fact]
        public async Task Delete()
        {
            var result = await controller.Delete(1);
            Assert.IsType<ActionResult<PublisherDto>>(result);
        }
    }
}
