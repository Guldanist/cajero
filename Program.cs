using System;

namespace CajeroAutomatico
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool flag = true;
            do
            {
                //Console.WriteLine("Hello World!");
                Console.WriteLine("Este es un Cajero Automatico!!!");
                Console.WriteLine("1. Consultar Saldo");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Retirar");
                Console.WriteLine("0. Terminar");
                Console.WriteLine("Teclea el Numero de la opcion que desee: ");
                int n;
                n = int.Parse(Console.ReadLine());
                //if (n == 1)
                //{
                //    Cliente.Consultar_saldo();
                //}
                //if (n == 2)
                //{
                //    Cliente.Depositar();
                //}
                //if (n == 3)
                //{
                //    Cliente.Retirar();

                //}
                //if (n == 0)
                //{
                //    Cliente.Terminar();
                //    flag = false;
                //}
            } while (flag==false);

           




        }
    }
}
