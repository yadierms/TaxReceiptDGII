using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TaxReceipt.API.Controllers;
using TaxReceipt.API.DTOs.Contribuyente;
using TaxReceipt.API.Interfaces.Service;

namespace TaxReceipt.Tests.Controller
{
    public class ContribuyenteControllerTests
    {
        private readonly Mock<IContribuyenteService> _contribuyenteService;
        private readonly ILogger<ContribuyenteController> _loggerMock;


        public ContribuyenteControllerTests()
        {
            _loggerMock = null;
            _contribuyenteService = new Mock<IContribuyenteService>();
        }

        [Fact]
        public async void ContribuyenteController_GetAllContribuyentes_ReturnOk()
        {
            //Arrange
            var contribuyentes = new Mock<IEnumerable<ContribuyenteDTO>>();
            _contribuyenteService.Setup(x => x.GetAllContribuyentes()).ReturnsAsync(contribuyentes.Object);
            var controller = new ContribuyenteController(_contribuyenteService.Object, _loggerMock);
            // Act
            var result = await controller.GetAllContribuyentes();
            // Assert
            var resultAction = result.Result as OkObjectResult;

            resultAction.Should().NotBeNull();
            resultAction.Should().BeOfType(typeof(OkObjectResult));


        }

    }
}
