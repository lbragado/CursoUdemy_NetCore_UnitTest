using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public interface ILoggerGeneral {
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceDespuesRetiro(int balanceDespuesRetiro);
    }
    public class LoggerGeneral : ILoggerGeneral
    {
        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            if (balanceDespuesRetiro >= 0)
            {
                return true;
                Console.WriteLine("exito");
            }
            else
            {
                return false;
                Console.WriteLine("error");
            }
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }

    /// <summary>
    /// Esta clase será utilizada en nuestras pruebas unitarias, el objetivo es que no tenga  operaciones que pudiéran
    /// afectar los resultados de las pruebas, en este caso solo hacía un Console.Wirteline pero si llegara a tener muchas
    /// operaciones podrían influir en los resultados de las preubas, por eso se hacen estos objetos FAKE.
    /// </summary>
    public class LoggerFake : ILoggerGeneral
    {
        public bool LogBalanceDespuesRetiro(int balanceDespuesRetiro)
        {
            throw new NotImplementedException();
        }

        public bool LogDatabase(string message)
        {
            throw new NotImplementedException();
        }

        public void Message(string message)
        {
            //Esta clase FAKE no hace nada para no influir en nuestras pruebas 
        }
    }
}
