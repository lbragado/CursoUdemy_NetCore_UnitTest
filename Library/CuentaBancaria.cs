using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class CuentaBancaria
    {
        private readonly ILoggerGeneral _loggerGeneral;
        public int Balance { get; set; }

        public CuentaBancaria(ILoggerGeneral loggerGeneral)
        {
            Balance = 0;
            _loggerGeneral = loggerGeneral;
        }

        public bool Deposito(int monto) {

            _loggerGeneral.Message($"Está depositando la cantidad de: {monto}");
            Balance += monto;
            return true;
        }

        public bool Retiro(int monto) {
            if (monto <= Balance)
            {
                _loggerGeneral.LogDatabase($"Monto de retiro: {monto.ToString()}");
                Balance -= monto;
                return _loggerGeneral.LogBalanceDespuesRetiro(Balance);
            }
            else
                return _loggerGeneral.LogBalanceDespuesRetiro(Balance - monto); ;
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}
