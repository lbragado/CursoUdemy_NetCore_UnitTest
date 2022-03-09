using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    [TestFixture]
    public class ClienteNUnitTests
    {        
        private Cliente cliente;

        [SetUp]
        public void Setup()
        {
            cliente = new Cliente();
        }

        [Test]
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
            Assert.Multiple(() => {

                Assert.That(cliente.NombreCliente, Is.EqualTo("Luis Bragado"));
                Assert.AreEqual(cliente.NombreCliente, "Luis Bragado");
                Assert.That(cliente.NombreCliente, Does.Contain("Luis"));
                Assert.That(cliente.NombreCliente, Does.Contain("luis").IgnoreCase);
                Assert.That(cliente.NombreCliente, Does.StartWith("luis").IgnoreCase);
                Assert.That(cliente.NombreCliente, Does.EndWith("bragado").IgnoreCase);

        }
            );
        }

        [Test]
        public void ClienteNombre_NoValues_ReturnNull()
        {
            //1. Arrange
            //Cliente cliente = new Cliente();  //Se inicializa en el método Setup

            //2. Act
            //cliente.NombreCliente = cliente.CrearNombreCompleto("Luis", "Bragado");
            
            Assert.IsNull(cliente.NombreCliente);
        }

        [Test]
        public void DescuentoEvaluacion_DefaultClient_ReturnsDescuentoIntervalo()
        {
            //1. Arrange

            //2. Act
            cliente.CrearNombreCompleto("Pedro", "Pecas");
            int descuento = cliente.Descuento;

            Assert.That(descuento, Is.InRange(5, 24));
        }

        [Test]
        public void CrearNombreCompleto_InputNombre_ReturnsNotNull()
        {
            // Act
            cliente.CrearNombreCompleto("Gerry", "");

            Assert.IsNotNull(cliente.NombreCliente);
            Assert.IsFalse(string.IsNullOrEmpty(cliente.NombreCliente));
        }

        [Test]
        public void ClienteNombre_InputNombreEnBlanco_ThrowsException()
        {
            //Validaremos que al llamar al método CrearNombreCompleto se esté lanzando la excepción ArgumentException
            //con el mensaje "El nombre está vacío"
            var exceptionDetalle = Assert.Throws<ArgumentException>(() => cliente.CrearNombreCompleto("", "Mendez"));
            Assert.AreEqual("El nombre está vacío", exceptionDetalle.Message);

            //Esta también es una forma similar a la anterior para validar que el mensaje lanzado sea: "El nombre está vacío"
            Assert.That(()=>cliente.CrearNombreCompleto("","Mendez2"), 
                Throws.ArgumentException.With.Message.EqualTo("El nombre está vacío"));

            //Validaremos que al llamar al método CrearNombreCompleto y se pase el argumento Nombre vacío deberá
            //lanzarse la excepción del tipo ArgumentException
            Assert.Throws<ArgumentException>(()=> cliente.CrearNombreCompleto("", "Pecas"));

            //Esta forma  es similar a la anterior, se valida que el tipo de excepción ArgumentException haya sido
            //lanzada cuando el parámetro Nombre esté vacío. 
            Assert.That(
                    ()=> cliente.CrearNombreCompleto("", "Pecas"), Throws.ArgumentException
                );
        }

        [Test]
        public void GetClienteDetalle_CrearClienteConMenos500TotalOrder_ReturnsClienteBasico()
        {
            //Seteamos el valor OrderTotal y que el método GetClienteDetalle en base a su valor determina el tipo de
            //objeto que debe regresar 
            cliente.OrderTotal = 150;

            var resultado = cliente.GetClienteDetalle();    

            //Aquí estaremos validando que nos esté regresando un objeto de tipo ClienteBasico
            Assert.That(resultado, Is.TypeOf<ClienteBasico>());
        }

        [Test]
        public void GetClienteDetalle_CrearClienteConMas500TotalOrder_ReturnsClientePremium()
        {
            //Seteamos el valor OrderTotal y que el método GetClienteDetalle en base a su valor determina el tipo de
            //objeto que debe regresar 
            cliente.OrderTotal = 700;

            var resultado = cliente.GetClienteDetalle();

            //Aquí estaremos validando que nos esté regresando un objeto de tipo ClienteBasico
            Assert.That(resultado, Is.TypeOf<ClientePremium>());
        }

    }
}
