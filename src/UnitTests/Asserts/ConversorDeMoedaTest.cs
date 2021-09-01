using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CasaDeCambio;
using Xunit;

namespace UnitTests.Asserts
{
    public class ConversorDeMoedaTest
    {
        #region Happy path
        [Fact]
        public void ConverterParaReal_FactTest()
        {
            //Arrange
            var conversor = new ConversorDeMoeda();
            decimal valor = 3;
            decimal taxa = 1.5m;
            int decimais = 4;
            decimal resultadoEsperado = 2;
 
            //Act
            var actual = conversor.ConverterParaReal(valor, taxa, decimais);
 
            //Assert
            Assert.Equal(resultadoEsperado, actual);
        }
        
        [Theory]
        [InlineData(0, 3, 0)]
        [InlineData(3, 1.5, 2)]
        [InlineData(3.75, 2.5, 1.5)]
        public void ConverterParaReal_TheoryTestWithInlineData(decimal valor, decimal taxa, decimal resultadoEsperado)
        {
            //Arrange
            var conversor = new ConversorDeMoeda();
            int decimais = 4;
 
            //Act
            var actual = conversor.ConverterParaReal(valor, taxa, decimais);
 
            //Assert
            Assert.Equal(resultadoEsperado, actual);
        }
        
        [Theory]
        [ClassData(typeof(ConversorDeMoedaTestData))]
        public void ConverterParaReal_TheoryTestWithClassData(decimal valor, decimal taxa, decimal resultadoEsperado)
        {
            //Arrange
            var conversor = new ConversorDeMoeda();
            int decimais = 4;
 
            //Act
            var actual = conversor.ConverterParaReal(valor, taxa, decimais);
 
            //Assert
            Assert.Equal(resultadoEsperado, actual);
        }
        
        [Theory]
        [MemberData(nameof(PropertyData))]
        public void ConverterParaReal_TheoryTestWithPropertyMemberData(decimal valor, decimal taxa, decimal resultadoEsperado)
        {
            //Arrange
            var conversorDeMoeda = new ConversorDeMoeda();
            var decimais = 4;
 
            //Act
            var actual = conversorDeMoeda.ConverterParaReal(valor, taxa, decimais);
 
            //Assert
            Assert.Equal(resultadoEsperado, actual);
        }
        
        [Theory]
        [MemberData(nameof(MethodGetData), parameters: 3)]
        public void ConverterParaReal_TheoryTestWithMethodMemberData(decimal valor, decimal taxa, decimal resultadoEsperado)
        {
            //Arrange
            var conversor = new ConversorDeMoeda();
            int decimais = 4;
 
            //Act
            var actual = conversor.ConverterParaReal(valor, taxa, decimais);
 
            //Assert
            Assert.Equal(resultadoEsperado, actual);
        }
        
        // [Theory]
        //[MemberData(nameof(ConversorDeMoeadeData.Data), MemberType= typeof(ConversorDeMoeadeData))]
        // public void ConverterParaReal_TheoryTestWithPropertyMemberDataExternalClass(decimal valor, decimal taxa, decimal resultadoEsperado)
        // {
        //     //Arrange
        //     var conversor = new ConversorDeMoeda();
        //     int decimais = 4;
        //
        //     //Act
        //     var actual = conversor.ConverterParaReal(valor, taxa, decimais);
        //
        //     //Assert
        //     Assert.Equal(resultadoEsperado, actual);
        // }
        
        public static IEnumerable<object[]> PropertyData =>
            new List<object[]>
            {
                new object[] { 0, 3, 0 },
                new object[] { 3, 1.5, 2 },
                new object[] { 3.75, 2.5, 1.5 }
            };

        public static IEnumerable<object[]> MethodGetData(int numTests)
        {
            var allData = new List<object[]>
            {
                new object[] { 0, 3, 0 },
                new object[] { 3, 1.5, 2 },
                new object[] { 3.75, 2.5, 1.5 },
            };
            return allData.Take(numTests);
        }

        #endregion
        
        #region Failure conditions
        [Fact]
        public void ConverterParaReal_ThrowsExceptionSeTaxaZero()
        {
            var converter = new ConversorDeMoeda();
            const decimal valor = 1;
            const decimal taxa = 0;
            const int decimais = 2;
            Assert.Throws<ArgumentException>(
                () => converter.ConverterParaReal(valor, taxa, decimais));
        }
        #endregion
    }
    
    public class ConversorDeMoedaTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, 3, 0 };
            yield return new object[] { 3, 1.5, 2 };
            yield return new object[] { 3.75, 2.5, 1.5 };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}