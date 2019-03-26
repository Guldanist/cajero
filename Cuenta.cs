namespace scrumBanco
{
    class Cuenta
    {
        string nroCuenta;
        decimal monto;
        char moneda;

        public string NroCuenta { get => nroCuenta; set => nroCuenta = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public char Moneda { get => moneda; set => moneda = value; }
    }
}