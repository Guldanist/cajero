namespace cajeroAutomatico
{
    class Cuenta
    {
        string nroCuenta;
        double monto;
        char moneda;
        public string NroCuenta
        {
            get
            {
                return nroCuenta;
            }

            set
            {
                nroCuenta = value;
            }
        }
        public double Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }
        public char Moneda
        {
            get
            {
                return moneda;
            }

            set
            {
                moneda = value;
            }
        }
    }
}
