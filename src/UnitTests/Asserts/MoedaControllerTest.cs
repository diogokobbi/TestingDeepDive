using CasaDeCambio.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace UnitTests.Asserts
{
    //Apenas para estudo. A lógica de negócio deve ficar em serviços que podem ser testados facilmente
    public class MoedaControllerTest
    {
        [Fact]
        public void Convert_ReturnsValue()
        {
            var controller = new MoedaController();
            var model = new ParametrosConversaoModel
            {
                Valor = 1,
                TaxaDeCambio = 3,
                Decimais = 2,
            };
 
            ActionResult<decimal> result = controller.Converter(model);
            Assert.NotNull(result);
        }
        
        [Fact]
        public void Convert_ReturnsBadRequestWhenInvalid()
        {
            var controller = new MoedaController();
            var model = new ParametrosConversaoModel
            {
                Valor = 1,
                TaxaDeCambio = -2,
                Decimais = 2,
            };
 
            controller.ModelState.AddModelError(
                nameof(model.TaxaDeCambio),
                "Taxa de câmbio deve ser maior que zero"
            );
 
            ActionResult<decimal> result = controller.Converter(model);
 
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}