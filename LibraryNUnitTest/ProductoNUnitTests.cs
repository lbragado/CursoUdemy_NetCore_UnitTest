using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    [TestFixture]
    public class ProductoNUnitTests
    {
        [Test]
        public void GetPrecio_PremiumCliente_ReturnsPrecio()
        {
            //1. Arrange
            Producto producto = new Producto() { Precio = 50 };

            //2. Act    - Recordemos que también podemos pasar un Moq de ICliente
            var resultado = producto.GetPrecio(new Cliente() { IsPremium=true }); 

            //3. Assert
            var valorEsperado = 40; //40 es el valor esperado porque a 50 multiplica por 0.8
            Assert.That(resultado, Is.EqualTo(valorEsperado));
        }

        [Test]
        public void GetPrecio_PremiumClienteMoq_ReturnsPrecio()
        {
            //1. Arrange
            Producto producto = new Producto() { Precio = 50 };

            var clienteMoq = new Mock<ICliente>();
            //Establecemos el valor en la propiedad IsPremium, en la parte Returns(true) estamos indicando
            //que el valor de la propiedad tendrá un valor de true
            clienteMoq.Setup(c => c.IsPremium).Returns(true);

            //2. Act
            //Podemos también pasarle una instancia de un objeto, como no tiene clases heredades que afecten podría ser
            //buena opción sólo pasarle la instancia y así no tener que generar la interface, pero si requerimos generar un MOQ
            //entones nuestra clase Cliente tendrá que tener su interface ICliente para poder crear un MOQ, así mismo,
            //el método a evaluar deberá recibir la interface  en lugar de la clase.
            var resultado = producto.GetPrecio(clienteMoq.Object);            

            //3. Assert
            var valorEsperado = 40; //40 es el valor esperado porque a 50 multiplica por 0.8
            Assert.That(resultado, Is.EqualTo(valorEsperado));
        }
    }
}
