using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Library
{
    public class OperacionXUnitTests
    {
        [Fact]
        public void SumarNumeros_InputDosNumeros_GetValorCorrecto()
        {
            //1. Arrange - Inicializar varialbes/componentes que ejecutarán la prueba
            Operacion op = new Operacion();
            int numero1Test = 50;
            int numero2Test = 69;
            //2. Act
            int resultado = op.SumarNumeros(numero1Test, numero2Test);

            //3. Assert
            //Evaluaremos si el resultado es igual al valor esperado
            Assert.Equal(119, resultado);
        }

        [Fact]
        public void IsValorPar_InputNumeroInpar_ReturnFalse()
        {
            //1. Arrange
            Operacion op = new Operacion();
            int numeroInpar = 7;

            //2. Act
            bool resultado = op.IsValorPar(numeroInpar);

            //3. Assert
            Assert.False(resultado);
            
            Assert.Equal(resultado, false);    //También podríamos compararlo así
        }

        [Theory]    //Cuando queramos ejecutar varios TestCases se usa Theory
        [InlineData(100, true)]
        [InlineData(2, true)]
        public void IsValorPar_InputNumeroPar_ReturnTrue(int numeroInpar, bool expectedResult)
        {
            //El parámetro numeroX sólo lo agregamos para ejemplificar si queremos pasar varios parámetros

            //1. Arrange
            Operacion op = new Operacion();            

            //2. Act
            bool resultado = op.IsValorPar(numeroInpar);

            //3. Assert
            Assert.Equal(resultado, expectedResult);    //Forma 1 
                
            Assert.True(resultado);                     //Forma 2 
        }

        [Theory]    //Cuando queramos ejecutar varios TestCases se usa Theory
        [InlineData(2.2, 2.5)]    //Resultado de be ser 4.7
        [InlineData(1.6, 2.5)]    //Reusltado debe ser 4.1
        public void SumarDecimal_InputDosDecimales_GetValorCorrecto(double decimal1Test, double decimal2Test)
        {
            //1. Arrange - Inicializar varialbes/componentes que ejecutarán la prueba
            Operacion op = new Operacion();
            
            //2. Act
            double resultado = op.SumarDecimal(decimal1Test, decimal2Test);

            //3. Assert
            //Con el 3er parámetro (delta se llama) especificamos que tenga un rango de -0.5 , +0.5
            //es decir, el rango iría de 4 (4.5-0.5) a 5 (4.5+0.5) si el resultado cae en esos parámetro será exitoso
            Assert.Equal(4.5, resultado,0.5);
        }

        [Fact]
        public void GetListNumerosImpares_InputMinimoMaximoIntervalos_ReturnsListaImpares()
        {
            //1. Arrange
            Operacion op = new Operacion();
            List<int> numerosImparesEsperados = new List<int>() { 5, 7, 9};

            //2. Act
            List<int> numerosResultados = op.GetListNumerosImpares(5, 10);

            //Assert
            //Comparación si las colecciones son iguales 
            Assert.Equal(numerosImparesEsperados, numerosResultados);            

            //Validamos que un elemento esté dentro de la colección 
            Assert.Contains(5, numerosResultados);

            //Validamos que la colección no esté vacía
            Assert.NotEmpty(numerosResultados);

            //Validamos que la lista tenga cierto número de elementos
            Assert.Equal(3, numerosResultados.Count);

            //Validamos que un valor NO esté en la lista, es decir si el número que se especifica se encuentra entonces será fallida la prueba
            Assert.DoesNotContain(100, numerosResultados);

            //Validaremos si la lista está ordenada ascendentemente (podemos usar descendente también)
            Assert.Equal(numerosResultados.OrderBy(u => u), numerosResultados);

            //Valida si existen números duplicados en la colección
            //Assert.That(numerosResultados, Is.Unique);    //Esto NO existe en XUnit
        }
    }
}
