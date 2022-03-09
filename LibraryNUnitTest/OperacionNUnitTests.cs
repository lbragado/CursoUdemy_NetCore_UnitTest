using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    [TestFixture]
    public class OperacionNUnitTests
    {
        [Test]
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
            Assert.AreEqual(119, resultado);
        }

        [Test]
        public void IsValorPar_InputNumeroInpar_ReturnFalse()
        {
            //1. Arrange
            Operacion op = new Operacion();
            int numeroInpar = 7;

            //2. Act
            bool resultado = op.IsValorPar(numeroInpar);

            //3. Assert
            Assert.IsFalse(resultado);
            //Assert.That(resultado, Is.EqualTo(false));    //También podríamos compararlo así
        }

        [Test]
        [TestCase(100, 5, ExpectedResult =true)]
        [TestCase(2, 0, ExpectedResult =true)]
        [TestCase(3, 1, ExpectedResult =false)]
        public bool IsValorPar_InputNumeroPar_ReturnTrue(int numeroInpar, int numeroX)
        {
            //El parámetro numeroX sólo lo agregamos para ejemplificar si queremos pasar varios parámetros

            //1. Arrange
            Operacion op = new Operacion();            

            //2. Act
            bool resultado = op.IsValorPar(numeroInpar);

            //3. Assert
            //Assert.IsTrue(resultado);                       //Esta es la forma clásica
            //Assert.That(resultado, Is.EqualTo(true));       //Esta es la forma con Restricciones

            return resultado;
        }

        [Test]
        [TestCase(2.2, 2.5)]    //Resultado de be ser 4.7
        [TestCase(1.6, 2.5)]    //Reusltado debe ser 4.1
        public void SumarDecimal_InputDosDecimales_GetValorCorrecto(double decimal1Test, double decimal2Test)
        {
            //1. Arrange - Inicializar varialbes/componentes que ejecutarán la prueba
            Operacion op = new Operacion();
            
            //2. Act
            double resultado = op.SumarDecimal(decimal1Test, decimal2Test);

            //3. Assert
            //Con el 3er parámetro (delta se llama) especificamos que tenga un rango de -0.5 , +0.5
            //es decir, el rango iría de 4 (4.5-0.5) a 5 (4.5+0.5) si el resultado cae en esos parámetro será exitoso
            Assert.AreEqual(4.5, resultado,0.5);
        }

        [Test]
        public void GetListNumerosImpares_InputMinimoMaximoIntervalos_ReturnsListaImpares()
        {
            //1. Arrange
            Operacion op = new Operacion();
            List<int> numerosImparesEsperados = new List<int>() { 5, 7, 9};

            //2. Act
            List<int> numerosResultados = op.GetListNumerosImpares(5, 10);

            //Assert
            Assert.That(numerosResultados, Is.EquivalentTo(numerosImparesEsperados));
            Assert.AreEqual(numerosResultados, numerosImparesEsperados);

            Assert.That(numerosResultados, Does.Contain(5));
            Assert.Contains(5, numerosResultados);

            Assert.That(numerosResultados, Is.Not.Empty);

            //Validamos que la lista tenga cierto número de elementos
            Assert.That(numerosResultados.Count, Is.EqualTo(3));

            //Validamos que un valor NO esté en la lista, es decir si el número que se especifica se encuentra entonces será fallida la prueba
            Assert.That(numerosResultados, Has.No.Member(100));

            //Validaremos si la lista está ordenada ascendentemente (podemos usar descendente también)
            Assert.That(numerosResultados, Is.Ordered.Ascending);

            //Valida si existen números duplicados en la colección
            Assert.That(numerosResultados, Is.Unique);
        }
    }
}
