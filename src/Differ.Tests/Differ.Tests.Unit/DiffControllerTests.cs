using Differ.Application.Interfaces;
using Differ.Application.ViewModels;
using Differ.Services.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Differ.Tests.Unit
{
    public class DiffControllerTests
    {
        private readonly Mock<IDiffAppService> _diffAppServiceMock;
        private readonly Mock<HttpContext> _contextMock;

        public DiffControllerTests()
        {
            _diffAppServiceMock = new Mock<IDiffAppService>();
            _contextMock = new Mock<HttpContext>();
        }

        [Fact]
        public async Task UploadLeftDiff_success()
        {
            //Arrange
            LeftDataViewModel fakeData = new LeftDataViewModel()
            {
                LeftData = "abcdefg"
            };

            _diffAppServiceMock.Setup(x => x.SaveLeftData(It.IsAny<LeftDataViewModel>()))
                .Returns(Task.FromResult(new Guid()));

            //Act
            var diffController = new DiffController(_diffAppServiceMock.Object);
            diffController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await diffController.UploadLeftDiff(fakeData);

            //Assert
            Assert.Equal((actionResult as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task UploadRightDiff_success()
        {
            //Arrange
            RightDataViewModel fakeData = new RightDataViewModel()
            {
                Id = new Guid(),
                RightData = "abcdefg"
            };

            _diffAppServiceMock.Setup(x => x.SaveRightData(It.IsAny<RightDataViewModel>()))
                .Returns(Task.CompletedTask);

            //Act
            var diffController = new DiffController(_diffAppServiceMock.Object);
            diffController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await diffController.UploadRightDiff(fakeData);

            //Assert
            Assert.Equal((actionResult as OkResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task CalculateDiff_success()
        {
            //Arrange
            Guid fakeGuid = new Guid();
            DiffRequestViewModel fakeData = new DiffRequestViewModel()
            {
                Id = fakeGuid
            };
            DiffViewModel fakeViewModel = GetDiffViewModelFake(fakeGuid);
            _diffAppServiceMock.Setup(x => x.CalculateDiff(It.IsAny<Guid>()))
                .Returns(Task.FromResult(fakeViewModel));

            //Act
            var diffController = new DiffController(_diffAppServiceMock.Object);
            diffController.ControllerContext.HttpContext = _contextMock.Object;
            var actionResult = await diffController.CalculateDiff(fakeData);

            //Assert
            Assert.Equal((actionResult as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.Equal((((ObjectResult)actionResult).Value as DiffViewModel).Id, fakeGuid);
        }

        private DiffViewModel GetDiffViewModelFake(Guid guid)
        {
            return new DiffViewModel()
            {
                Id = guid,
                Message = "Ok fake message",
                Differences = new List<DifferenceViewModel>()
                {
                    new DifferenceViewModel()
                    {
                        Length = 1,
                        Offset = 0
                    }
                    ,new DifferenceViewModel()
                    {
                        Length = 1,
                        Offset = 2
                    }
                }
            };
        }
    }
}