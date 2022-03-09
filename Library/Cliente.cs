using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public interface ICliente {

        string NombreCliente { get; set; }
        int Descuento { get; set; }
        int OrderTotal { get; set; }
        bool IsPremium { get; set; }

        string CrearNombreCompleto(string nombre, string apellido);        
        TipoCliente GetClienteDetalle();
    }

    public class Cliente:ICliente
    {
        public string NombreCliente { get; set; }
        public int Descuento { get; set; }
        public int OrderTotal { get; set; }
        public bool IsPremium { get; set; }

        public Cliente()
        {
            IsPremium = false;
        }

        public string CrearNombreCompleto(string nombre, string apellido)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre está vacío");
            
            NombreCliente = $"{nombre} {apellido}";
            
            Descuento = 10;
            
            return NombreCliente;
        }

        public TipoCliente GetClienteDetalle() {
            if (OrderTotal < 500)
                return new ClienteBasico();
            else
                return new ClientePremium();
        }
    }

    public class TipoCliente { }
    public class ClienteBasico:TipoCliente { }
    public class ClientePremium:TipoCliente { }
}
