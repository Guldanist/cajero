namespace scrumBanco
{
    class Cuenta
    {
        string nroCuenta;
        double monto;
        char moneda;

        public string NroCuenta { get => nroCuenta; set => nroCuenta = value; }
        public double Monto { get => monto; set => monto = value; }
        public char Moneda { get => moneda; set => moneda = value; }
    }
}