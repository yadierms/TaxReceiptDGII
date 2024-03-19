using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TaxReceipt.API.Controllers;
using TaxReceipt.API.DTOs.Comprobante;
using TaxReceipt.API.Interfaces.Service;

namespace TaxReceipt.Tests.Controller
{
    public class ComprobranteControllerTests
    {

        private readonly Mock<IComprobanteService> _comprobanteService;
        private readonly ILogger<ComprobanteController> _loggerMock;

        public ComprobranteControllerTests()

        {
            _loggerMock = null;
            _comprobanteService = new Mock<IComprobanteService>();
        }
        [Fact]
        public async void ComprobanteController_GetAllComprobantes_ReturnOk()
        {
            //Arrange
            var comprobantes = new Mock<IEnumerable<ComprobanteDTO>>();
            var controller = new ComprobanteController(_comprobanteService.Object, _loggerMock);
            _comprobanteService.Setup(x => x.GetAllComprobantes()).ReturnsAsync(comprobantes.Object);
            // Act
            var result = await controller.GetAllComprobantes();
            // Assert
            var resultAction = result.Result as OkObjectResult;

            resultAction.Should().NotBeNull();
            resultAction.Should().BeOfType(typeof(OkObjectResult));

        }

        [Theory]
        [InlineData(123456789)]
        [InlineData(987654321)]
        public async Task ComprobanteController_GetAllContribuyentesByRnc_ReturnOk(long rncCedula)
        {
            // Arrange
            var expectedComprobantes = new List<ComprobanteDTO>(); // Mocked list of Comprobantes
            _comprobanteService.Setup(x => x.GetAllComprobantesByRnc(rncCedula)).ReturnsAsync(expectedComprobantes);
            var controller = new ComprobanteController(_comprobanteService.Object, _loggerMock);

            // Act
            var result = await controller.GetAllComprobantesByRnc(rncCedula);

            // Assert
            var resultAction = result.Result as OkObjectResult;

            resultAction.Should().BeOfType<OkObjectResult>()
               .Which.Value.Should().BeEquivalentTo(expectedComprobantes);
        }

    }
}
