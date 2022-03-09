using Moq;
using Xunit;

namespace Library
{
    public class CuentaBancariaXUnitTests
    {        
        [Fact]
        public void Deposito_InputMonto_ReturnTrue()
        {
            //1. Arrange
            CuentaBancaria cuentaBancaria = new CuentaBancaria(new LoggerFake());

            //2. Act
            var resultado = cuentaBancaria.Deposito(100);

            //3. Assert
            //Validamos si el resultado del depósito es 100
            Assert.True(resultado);

            //2da forma de probar, validamos si el balance es igual a 100 ya que inicalmente el balance tenía 0
            Assert.Equal(100, cuentaBancaria.GetBalance());
        }

        [Fact]
        public void Deposito_InputMontoMocking_ReturnTrue()
        {
            //1. Arrange
            //En lugar de Instanciar un objeto real ahora implementaremos un MOQ
            var mocking = new Mock<ILoggerGeneral>();   
            CuentaBancaria cuentaBancaria = new CuentaBancaria(mocking.Object);

            //2. Act
            var resultado = cuentaBancaria.Deposito(100);

            //3. Assert
            //Validamos si el resultado del depósito es 100
            Assert.True(resultado);

            //2da forma de probar, validamos si el balance es igual a 100 ya que inicalmente el balance tenía 0
            Assert.Equal(100, cuentaBancaria.GetBalance());
        }
        [Theory]
        [InlineData(200,100)]
        [InlineData(200,150)]
        public void Retiro_Retiro100ConBalance200_ReturnsTrue(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();

            //Indicamos que para el método LogDatabase se puede recibi cualquier string
            loggerMock.Setup( u => 
                   u.LogDatabase(It.IsAny<string>())).Returns(false);

            //Podemos indicar por ejemplo que el parámetro que recibe el método LogBalanceDespuesRetiro
            //sea mayor a cero ... de la siguiente forma: It.Is<int>(x=>x>0))
            //Si queremos que el valor esté dentro de un rango sería:
            //It.IsInRange<int>(int.MinValue,-1,Moq.Range.Inclusive)  
            //int.MinValue sería el valor mínimo para un int hasta -1 pero podemos especificar valores como de 10 a 20 o algo parecido 
            loggerMock.Setup(u=>
                   u.LogBalanceDespuesRetiro(It.Is<int>(x=>x>0))).Returns(true);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);
            
            cuentaBancaria.Deposito(balance);

            var resultado = cuentaBancaria.Retiro(retiro);

            Assert.True(resultado);
        }

        [Theory]
        [InlineData(200, 150)]
        public void Retiro_Retiro300ConBalance200_ReturnsFalse(int balance, int retiro)
        {
            var loggerMock = new Mock<ILoggerGeneral>();

            //Indicamos que para el método LogDatabase se puede recibi cualquier string
            //loggerMock.Setup(u =>
            //      u.LogDatabase(It.IsAny<string>())).Returns(false);

            loggerMock.Setup(u =>
                   u.LogBalanceDespuesRetiro(It.IsAny<int>())).Returns(false);

            CuentaBancaria cuentaBancaria = new CuentaBancaria(loggerMock.Object);

            cuentaBancaria.Deposito(balance);

            var resultado = cuentaBancaria.Retiro(retiro);

            Assert.False(resultado);
        }
    }
}
