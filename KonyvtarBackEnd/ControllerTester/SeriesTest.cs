using KonyvtarBackEnd.Controllers;
using KonyvtarBackEnd.Dto;
using KonyvtarBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit; // Ensure to include the correct testing framework namespace (e.g., Xunit)

namespace ControllerTester
{
    public class SeriesTest
    {
        private readonly SeriesController controller;

        public SeriesTest()
        {
            this.controller = new SeriesController();
        }

        [Fact]
        public async Task GetAll()
        {
            var all = await controller.GetAll();
            Assert.IsType<OkObjectResult>(all.Result);
        }


        [Fact]
        public async Task Get()
        {
            // Arrange
            int seriesId = 1;

            // Act
            var actionResult = await controller.Get(seriesId); // Await the async method

            // Assert
            var result = Assert.IsType<ActionResult<SeriesDto>>(actionResult);
            Assert.NotNull(result);

            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result); // Check the inner result of ActionResult
            var cucc = Assert.IsType<Series>(okObjectResult.Value);
            Assert.Equal(seriesId.ToString(), cucc.Id.ToString());
        }

        [Fact]
        public async Task Post()
        {
            CreateOrModifySeriesDto dto = new CreateOrModifySeriesDto(1, "Test");
            var response = controller.Post(dto);
            Assert.IsType<ActionResult<SeriesDto>>(response.Result);
        }

        [Fact]
        public async Task Put()
        {
            CreateOrModifySeriesDto dto = new CreateOrModifySeriesDto(1, "Test");
            var response = controller.Put(1, dto);
            Assert.IsType<ActionResult<SeriesDto>>(response.Result);
        }

        [Fact]
        public async Task Delete()
        {
            var response = controller.Delete(1);
            Assert.IsType<ActionResult<SeriesDto>>(response.Result);
        }
    }
}
