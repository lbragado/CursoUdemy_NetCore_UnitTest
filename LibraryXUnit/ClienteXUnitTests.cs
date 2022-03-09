using System;
using Xunit;

namespace Library
{
    public class ClienteXUnitTests
    {
        private Cliente cliente;

        public ClienteXUnitTests()
        {
            cliente = new Cliente();
        }

        [Fact]
        public void CrearNombreCompleto_InputNombreApellido_ReturnNombreCompleto()
        {
            //1. Arrange
            //Cliente cliente = new Cliente();  //Se inicializa en el método Setup

            //2. Act
            cliente.NombreCliente = cliente.CrearNombreCompleto("Luis", "Bragado");

            //3. Assert
            //Permite ejecutar todos los casos de prueba incluso si alguno falla, ya que si no están dentro
            //de Assert.Multiple se detiene el log de ejecución en donde aparezca el primer caso de prueba fallido
            //es decir, ya no ejecutaría los demás casos de prueba
            Assert.Equal("Luis Bragado", cliente.NombreCliente);
            Assert.Contains("Luis", cliente.NombreCliente);
            Assert.StartsWith("Luis", cliente.NombreCliente);
            Assert.EndsWith("Bragado", cliente.NombreCliente);
        }

        [Fact]
        public void ClienteNombre_NoValues_ReturnNull()
        {
            //1. Arrange
            //Cliente cliente = new Cliente();  //Se inicializa en el método Setup

            //2. Act
            //cliente.NombreCliente = cliente.CrearNombreCompleto("Luis", "Bragado");

            Assert.Null(cliente.NombreCliente);
        }

        [Fact]
        public void DescuentoEvaluacion_DefaultClient_ReturnsDescuentoIntervalo()
        {
            //1. Arrange

            //2. Act
            cliente.CrearNombreCompleto("Pedro", "Pecas");
            int descuento = cliente.Descuento;

            Assert.InRange(descuento, 5, 24);
        }

        [Fact]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            // Act
            cliente.CrearNombreCompleto("Gerry", "");

            Assert.NotNull(cliente.NombreCliente);
            Assert.False(string.IsNullOrEmpty(cliente.NombreCliente));
        }

        [Fact]
        public void ClienteNombre_InputNombreEnBlanco_ThrowsException()
        {
            //Validaremos que al llamar al método CrearNombreCompleto se esté lanzando la excepción ArgumentException
            //con el mensaje "El nombre está vacío"
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Mendez"));
            Assert.Equal("El nombre está vacío", exceptionDetalle.Message);

            //Validaremos que al llamar al método CrearNombreCompleto y se pase el argumento Nombre vacío deberá
            //lanzarse la excepción del tipo ArgumentException
            Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Pecas"));
        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
        {
            //Seteamos el valor OrderTotal y que el método GetClienteDetalle en base a su valor determina el tipo de
            //objeto que debe regresar 
            cliente.OrderTotal = 150;

            var resultado = cliente.GetClienteDetalle();

            //Aquí estaremos validando que nos esté regresando un objeto de tipo ClienteBasico
            Assert.IsType<ClienteBasico>(resultado);
        }

        [Fact]
        public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClientePremium()
        {
            //Seteamos el valor OrderTotal y que el método GetClienteDetalle en base a su valor determina el tipo de
            //objeto que debe regresar 
            cliente.OrderTotal = 700;

            var resultado = cliente.GetClienteDetalle();

            //Aquí estaremos validando que nos esté regresando un objeto de tipo ClienteBasico
            Assert.IsType<ClientePremium>(resultado);
        }

    }
}
