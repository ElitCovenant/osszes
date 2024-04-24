using KonyvtarBackEnd.Controllers;
using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerTester
{
    public class AuthorTest
    {
        private readonly AuthorController controller = new AuthorController();

        [Fact]
        public async Task GetAll()
        {
            var result = await controller.GetAll();
            Assert.IsType<ActionResult<AuthorDto>>(result);
        }

        [Fact]
        public async Task Get()
        {
            var result = await controller.Get(1);
            Assert.IsType<ActionResult<AuthorDto>>(result);
        }

        [Fact]
        public async Task Post()
        {
            CreateOrModifyAuthorDto dto = new CreateOrModifyAuthorDto(1,"Test");
            var result = await controller.Post(dto);
            Assert.IsType<ActionResult<AuthorDto>>(result);
        }

        [Fact]
        public async Task Put()
        {
            CreateOrModifyAuthorDto dto = new CreateOrModifyAuthorDto(1, "Test");
            var result = await controller.Post(dto);
            Assert.IsType<ActionResult<AuthorDto>>(result);
        }

        [Fact]
        public async Task Delete()
        {
            var result = await controller.Delete(1);
            Assert.IsType<ActionResult<AuthorDto>>(result);
        }
    }
}
