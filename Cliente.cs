using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace scrumBanco
{
    class Cliente
    {
        string dni;
        string nombre;
        string apellido;
        List<Cuenta> cuentas;

        public Cliente()
        {

        }

        public string DNI { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        internal List<Cuenta> Cuentas { get => cuentas; set => cuentas = value; }

        public void IngresarDinero()
        {
            int dDeposito; //dinero a ingresar
            int cuenRetiro; //cuenta a la que ingresara dinero
            List<Cuenta> cuent = Cuentas;
            int i;
            for (i = 0; i < cuent.Count - 1; i++)
            {
                Console.WriteLine("{0}.- Cuenta: {1}", i + 1, cuentas[i].NroCuenta);
            }
            Console.WriteLine("A que cuenta desea ingresar dinero?");
            cuenRetiro = int.Parse(Console.ReadLine());
            cuenRetiro = cuenRetiro - 1;
            if (cuenRetiro < i - 1 && cuenRetiro > 0)
            {
                Console.WriteLine("Cuanto dinero quiere ingresar?");
                dDeposito = int.Parse(Console.ReadLine());
                cuentas[cuenRetiro].Monto = cuent[cuenRetiro].Monto + dDeposito;
                Console.WriteLine("Deposito exitoso");
            }
            else
            {
                Console.WriteLine("Cuenta no existente, se le redirigira al inicio");
            }
        }
        public void RetirarDinero()
        {
            int dRetiro; //dinero a retirar
            int cuenRetiro; //cuenta de la que retirara dinero            
            int i;
            for (i = 0; i < cuentas.Count - 1; i++)
            {
                Console.WriteLine("{0}.- Cuenta: {1}", i + 1, cuentas[i].NroCuenta);
            }
            Console.WriteLine("De que cuenta desea retirar dinero?");
            cuenRetiro = int.Parse(Console.ReadLine());
            cuenRetiro = cuenRetiro - 1;
            if (cuenRetiro < i - 1 && cuenRetiro > 0)
            {
                Console.WriteLine("Cuanto dinero quiere retirar?");
                dRetiro = int.Parse(Console.ReadLine());
                if (dRetiro > cuentas[cuenRetiro].Monto)
                {
                    Console.WriteLine("No dispone de los fondos suficientes");
                }
                else
                {
                    cuentas[cuenRetiro].Monto = cuentas[cuenRetiro].Monto - dRetiro;
                    Console.WriteLine("Retiro exitoso");
                }
            }
            else
            {
                Console.WriteLine("Cuenta no existente, se le redirigira al inicio");
            }
        }
    }
}