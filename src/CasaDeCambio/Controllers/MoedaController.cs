using CasaDeCambio;
using Microsoft.AspNetCore.Mvc;

namespace CasaDeCambio.Controllers  
{
    [Route("api/[controller]")]
    public class MoedaController : ControllerBase
    {
        //Apenas por simplicidade. Utilizar injeção de dependência
        private readonly ConversorDeMoeda _conversor = new ConversorDeMoeda();
        
        [HttpPost]
        public ActionResult<decimal> Converter(ParametrosConversaoModel parametros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            decimal result = _conversor.ConverterParaReal(parametros.Valor, parametros.TaxaDeCambio, parametros.Decimais);
     
            return result;
        }
    }

    public class ParametrosConversaoModel
    {
        public int Valor { get; set; }
        public int TaxaDeCambio { get; set; }
        public int Decimais { get; set; }
    }
}