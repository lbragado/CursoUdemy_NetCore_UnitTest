using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryMSTest
{
    [TestClass]
    public class OperacionMSTest
    {
        [TestMethod]
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
    }
}
