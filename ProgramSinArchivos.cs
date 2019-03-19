using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace scrumBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            string dni;
            bool flag = true;
            do
            {
                bool valido = false;
                Console.WriteLine("Ingrese su DNI");
                dni = Console.ReadLine();
                valido = Validar(dni);
                if (valido == true)
                {
                    do
                    {
                        Cliente clien = Crear(dni);
                        Console.WriteLine("Este es un Cajero Automatico!!!");
                        console.WriteLine($"DNI Cliente: {dni}");
                        Console.WriteLine("1. Consultar Saldo");
                        Console.WriteLine("2. Depositar");
                        Console.WriteLine("3. Retirar");
                        Console.WriteLine("0. Terminar");
                        Console.WriteLine("Teclee la opcion que desee: ");
                        int opc;
                        opc = int.Parse(Console.ReadLine());
                        if (opc == 1)
                        {
                            Consulta(dni);
                        }
                        if (opc == 2)
                        {
                        }
                        if (opc == 3)
                        {

                        }
                        if (opc == 0)
                        {
                            flag = false;
                        }
                        if (opc < 0 || opc > 3)
                        {
                            Console.WriteLine("Opcion no valida. Intente de nuevo");
                        }
                    } while (flag == true);
                }
                else
                {
                    Console.WriteLine("DNI no registrado o no invalido");
                }
            } while (true);
        }
        static public void Consulta(string dni)
        {
            StreamReader lectura = new StreamReader("./bd.txt");

            bool encontrado;
            encontrado = false;
            string[] campos = new string[6];
            char[] separador = { ',' };

            while (!lectura.EndOfStream)
            {                
                string cadena = lectura.ReadLine();

                while (cadena != null)
                {
                    campos = cadena.Split(separador);
                    if (campos[0].Trim().Equals(dni))
                    {
                        if (encontrado == false)
                        {
                            Console.WriteLine($"Nombre: {campos[1].Trim()}");
                            Console.WriteLine($"Apellido: {campos[2].Trim()}");
                            Console.WriteLine($"Cuenta: {campos[3].Trim()}");
                            Console.WriteLine($"Monto: {campos[4].Trim()}");
                            Console.WriteLine($"Moneda: {campos[5].Trim()}");
                            encontrado = true;
                        }
                        else
                        {
                            Console.WriteLine($"Cuenta: {campos[3].Trim()}");
                            Console.WriteLine($"Monto: {campos[4].Trim()}");
                            Console.WriteLine($"Moneda: {campos[5].Trim()}");
                        }
                    }
                    cadena = lectura.ReadLine();
                }
                if (encontrado == false)
                {
                    Console.WriteLine("no existe");
                }
                //lectura.Close();

                //Console.ReadKey();
            }
        }
        static public Cliente Crear(string DNI)
        {
            StreamReader lectura = new StreamReader("./bd.txt");

            int m = 0;
            int n = 3;
            string nombre = "";
            string apellido = "";
            string[,] cuenta = new string[m, n];
            bool encontrado;
            encontrado = false;
            string[] campos = new string[6];
            char[] separador = { ',' };

            while (!lectura.EndOfStream)
            {
                Console.WriteLine("ingrese numero de DNI");
                string busquedaDNI = Console.ReadLine();
                string cadena = lectura.ReadLine();

                while (cadena != null)
                {
                    campos = cadena.Split(separador);
                    if (campos[0].Trim().Equals(busquedaDNI))
                    {
                        if (encontrado == false)
                        {
                            DNI = campos[0].Trim();
                            nombre = campos[1].Trim();
                            apellido = campos[2].Trim();
                            m++;
                            cuenta[m - 1, 0] = campos[3].Trim();
                            cuenta[m - 1, 1] = campos[4].Trim();
                            cuenta[m - 1, 2] = campos[5].Trim();
                            encontrado = true;
                        }
                        else
                        {
                            m++;
                            cuenta[m - 1, 0] = campos[3].Trim();
                            cuenta[m - 1, 1] = campos[4].Trim();
                            cuenta[m - 1, 2] = campos[5].Trim();
                        }
                    }
                    cadena = lectura.ReadLine();
                }
            }
            Cliente obj = new Cliente(DNI, nombre, apellido, cuenta);
            return obj;
        }
        static public bool Validar(string DNI)
        {
            bool retornar=false;
            if (DNI.Length == 8)
            {
                StreamReader lectura = new StreamReader("./bd.txt");
                bool encontrado;
                encontrado = false;
                string[] campos = new string[6];
                char[] separador = { ',' };
                while (!lectura.EndOfStream)
                {
                    string cadena = lectura.ReadLine();
                    while (cadena != null)
                    {
                        campos = cadena.Split(separador);
                        if (campos[0].Trim().Equals(Convert.ToString(DNI)))
                        {
                            if (encontrado == false)
                            {                                
                                encontrado = true;

                            }
                        }
                        cadena = lectura.ReadLine();
                    }
                    if (encontrado == true)
                    {
                        retornar = true;
                    }
                }
                return retornar;
            }
            else
            {                
                return retornar;
            }
        }
    }
    class Cliente
    {
        string DNI;
        string nombre;
        string apellido;
        string[,] cuenta;

        public Cliente(string dni, string nom, string apel, string[,] cuen)
        {
            this.DNI = dni;
            this.nombre = nom;
            this.apellido = apel;
            this.cuenta = cuen;
        }

        public void IngresarDinero()
        {
            int dDeposito; //dinero a ingresar
            int cuenRetiro; //cuenta a la que ingresara dinero
            string[,] cuent = cuenta;
            int i;
            for (i = 0; i < cuent.Length - 1; i++)
            {
                Console.WriteLine("{0}.- Cuenta: {1}", i + 1, cuent[i, 0]);
            }
            Console.WriteLine("A que cuenta desea ingresar dinero?");
            cuenRetiro = int.Parse(Console.ReadLine());
            if (cuenRetiro < i - 1 && cuenRetiro > 0)
            {
                Console.WriteLine("Cuanto dinero quiere ingresar?");
                dDeposito = int.Parse(Console.ReadLine());
                cuent[cuenRetiro, 1] = (int.Parse(cuent[cuenRetiro, 1]) + dDeposito).ToString();
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
            string[,] cuent = cuenta;
            int i;            
            for (i = 0; i < cuent.Length - 1; i++)
            {
                Console.WriteLine("{0}.- Cuenta: {1}", i + 1, cuent[i, 0]);
            }
            Console.WriteLine("De que cuenta desea retirar dinero?");
            cuenRetiro = int.Parse(Console.ReadLine());
            if (cuenRetiro < i - 1 && cuenRetiro > 0)
            {
                Console.WriteLine("Cuanto dinero quiere retirar?");
                dRetiro = int.Parse(Console.ReadLine());
                if (dRetiro > int.Parse(cuent[cuenRetiro, 1]))
                {
                    Console.WriteLine("No dispone de los fondos suficientes");
                }
                else
                {
                    cuent[cuenRetiro, 1] = (int.Parse(cuent[cuenRetiro, 1]) - dRetiro).ToString();
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
