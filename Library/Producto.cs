using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }

        public double GetPrecio(Cliente cliente)
        {
            //Si es un cliente Premium se le hará un descuento del 8%
            if (cliente.IsPremium)
                return Precio * 0.8;
            else
                return Precio;
        }

        /// <summary>
        /// Para ejemplificar que podemos mandar a llamar a este método pasándole también la Interfaz y poder
        /// utilizar su MOQ 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public double GetPrecio(ICliente cliente)
        {
            //Si es un cliente Premium se le hará un descuento del 8%
            if (cliente.IsPremium)
                return Precio * 0.8;
            else
                return Precio;
        }
    }
}

