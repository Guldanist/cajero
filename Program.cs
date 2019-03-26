using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace cajeroAutomatico
{
    class Program
    {
        static void Main(string[] args)
        {
            string dni;
            bool flag = true;
            List<string> listaArchivo = new List<string>();
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
                        int pos = 0;
                        Console.WriteLine("Este es un Cajero Automatico!!!");
                        Console.WriteLine("1. Consultar Saldo");
                        Console.WriteLine("2. Depositar");
                        Console.WriteLine("3. Retirar");
                        Console.WriteLine("0. Terminar");
                        Console.WriteLine("Teclee la opcion que desee: ");
                        int opc;
                        opc = int.Parse(Console.ReadLine());
                        switch (opc)
                        {
                            case 1:
                                Consulta(dni);
                                break;
                            case 2:
                                pos = clien.IngresarDinero();
                                if (pos != -1)
                                {
                                    listaArchivo = CrearListaArchivo();
                                    ModificarArchivo(listaArchivo, pos, clien);
                                }
                                break;
                            case 3:
                                pos = clien.RetirarDinero();
                                if (pos != -1)
                                {
                                    listaArchivo = CrearListaArchivo();
                                    ModificarArchivo(listaArchivo, pos, clien);
                                }
                                break;
                            case 0:
                                flag = false;
                                break;
                            default:
                                Console.WriteLine("Opcion no valida. Intente de nuevo");
                                break;
                        }
                    } while (flag == true);
                }
            } while (true);
        }
        static public void Consulta(string dni)
        {
            StreamReader lectura = new StreamReader("./bd.txt");

            bool encontrado = false;
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
            }
            lectura.Close();
            if (encontrado == false)
            {
                Console.WriteLine("no existe");
            }
        }
        static public Cliente Crear(string DNI)
        {
            StreamReader lectura = new StreamReader("./bd.txt");
            Cliente obj = new Cliente();
            obj.Cuentas = new List<Cuenta>();
            Cuenta cuenta = new Cuenta();
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
                            cuenta.NroCuenta = campos[3].Trim();
                            cuenta.Monto = double.Parse(campos[4].Trim());
                            cuenta.Moneda = char.Parse(campos[5].Trim());
                            obj.Cuentas.Add(cuenta);
                            encontrado = true;
                        }
                        else
                        {
                            cuenta.NroCuenta = campos[3].Trim();
                            cuenta.Monto = double.Parse(campos[4].Trim());
                            cuenta.Moneda = char.Parse(campos[5].Trim());
                            obj.Cuentas.Add(cuenta);
                        }
                    }
                    cadena = lectura.ReadLine();
                }
                if (encontrado == false)
                {
                    Console.WriteLine("No existe DNI");
                }
            }
            lectura.Close();
            return obj;
        }
        static public bool Validar(string DNI)
        {
            bool retornar = false;
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
                            encontrado = true;
                        }
                        cadena = lectura.ReadLine();
                    }
                    if (encontrado == true)
                    {
                        retornar = true;
                    }
                }
                lectura.Close();
                return retornar;
            }
            else
            {
                Console.WriteLine("DNI no encontrado");
                return retornar;
            }
        }
        static public List<string> CrearListaArchivo()
        {
            StreamReader lectura = new StreamReader("./bd.txt");

            List<string> lista = new List<string>();

            while (!lectura.EndOfStream)
            {
                string cadena = lectura.ReadLine();

                while (cadena != null)
                {
                    lista.Add(cadena);
                    cadena = lectura.ReadLine();
                }
            }
            lectura.Close();
            return lista;
        }
        static public void ModificarArchivo(List<string> lista, int posicion, Cliente cliente)
        {
            string ruta = "./bd.txt";
            StreamReader lectura = new StreamReader(ruta);
            lectura.Close();
            string[] campos = new string[6];
            char[] separador = { ',' };

            string nuevaLinea = (cliente.DNI + "," + cliente.Nombre + "," + cliente.Apellido + "," +
                cliente.Cuentas[posicion].NroCuenta + "," + cliente.Cuentas[posicion].Monto + "," +
                cliente.Cuentas[posicion].Moneda);
            for (int i = 0; i < lista.Count - 1; i++)
            {
                for (int j = 0; j < cliente.Cuentas.Count - 1; j++)
                {
                    campos = lista[i].Split(separador);
                    if (campos[3].Trim().Equals(cliente.Cuentas[j].NroCuenta))
                    {
                        lista[i] = nuevaLinea;
                    }
                }
            }
            StreamWriter sw = new StreamWriter(ruta);
            sw.Flush();
            for (int i = 0; i < lista.Count-1; i++)
            {
                sw.WriteLine(lista[i]);
            }
            sw.Close();
        }
    }
}