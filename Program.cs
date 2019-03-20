using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
                            clien.IngresarDinero();
                        }
                        if (opc == 3)
                        {
                            clien.RetirarDinero();
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
            Cliente obj = new Cliente();
            int m = 0;
            bool encontrado;
            encontrado = false;
            string[] campos = new string[6];
            char[] separador = { ',' };

            while (!lectura.EndOfStream)
            {                
                string busquedaDNI = DNI;
                string cadena = lectura.ReadLine();

                while (cadena != null)
                {
                    campos = cadena.Split(separador);
                    if (campos[0].Trim().Equals(busquedaDNI))
                    {
                        if (encontrado == false)
                        {
                            obj.DNI = campos[0].Trim();
                            obj.Nombre = campos[1].Trim();
                            obj.Apellido = campos[2].Trim();                            
                            obj.Cuentas[m].NroCuenta =  campos[3].Trim();
                            obj.Cuentas[m].Monto = int.Parse(campos[4].Trim());
                            obj.Cuentas[m].Moneda = char.Parse(campos[5].Trim());
                            encontrado = true;
                        }
                        else
                        {
                            m++;
                            obj.Cuentas[m].NroCuenta = campos[3].Trim();
                            obj.Cuentas[m].Monto = int.Parse(campos[4].Trim());
                            obj.Cuentas[m].Moneda = char.Parse(campos[5].Trim());
                        }
                    }
                    cadena = lectura.ReadLine();
                }
            }            
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
}
