using System;

namespace CasaDeCambio
{
    public class ConversorDeMoeda
    {
        public decimal ConverterParaReal(decimal valor, decimal taxaDeCambio, int casasDecimais)
        {
            if (taxaDeCambio <= 0)
            {
                throw new ArgumentException(
                    "taxa de câmbio deve ser maior que zero",
                    nameof(taxaDeCambio));
            }
            var valueInGbp = valor / taxaDeCambio;
            return decimal.Round(valueInGbp, casasDecimais);
        }
    }
}