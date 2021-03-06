﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace scrumBanco
{
    class Cliente
    {
        string dni;
        string nombre;
        string apellido;
        List<Cuenta> cuentas;        

        public string DNI
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }
        public List<Cuenta> Cuentas
        {
            get
            {
                return cuentas;
            }

            set
            {
                cuentas = value;
            }
        }
        public Cliente()
        {

        }
        public int IngresarDinero()
        {
            CultureInfo culture = new CultureInfo("en-US");
            decimal dDeposito; //dinero a ingresar
            int cuenRetiro; //cuenta a la que ingresara dinero
            int i;
            Cuenta nuevaEjemplo = new Cuenta();
            for (i = 0; i < Cuentas.Count; i++)
            {
                Console.WriteLine("{0}. Cuenta: {1}", i + 1, Cuentas[i].NroCuenta);
            }
            Console.WriteLine("A que cuenta desea ingresar dinero?");
            cuenRetiro = int.Parse(Console.ReadLine());
            cuenRetiro = cuenRetiro - 1;            
            if (cuenRetiro < i && cuenRetiro >= 0)
            {
                Console.WriteLine("Cuanto dinero quiere ingresar?");
                dDeposito = decimal.Parse(Console.ReadLine(),culture);                
                Cuentas[cuenRetiro].Monto = Cuentas[cuenRetiro].Monto + dDeposito;                                
                Console.WriteLine("Deposito exitoso");
            }
            else
            {
                Console.WriteLine("Cuenta no existente, se le redirigira al inicio");
                cuenRetiro = -1;
            }
            return cuenRetiro;
        }
        public int RetirarDinero()
        {
            CultureInfo culture = new CultureInfo("en-US");
            decimal dRetiro; //dinero a retirar
            int cuenRetiro; //cuenta de la que retirara dinero            
            int i;
            for (i = 0; i < Cuentas.Count; i++)
            {
                Console.WriteLine("{0}.- Cuenta: {1}", i + 1, Cuentas[i].NroCuenta);
            }
            Console.WriteLine("De que cuenta desea retirar dinero?");
            cuenRetiro = int.Parse(Console.ReadLine());
            cuenRetiro = cuenRetiro - 1;
            if (cuenRetiro < i && cuenRetiro >= 0)
            {
                Console.WriteLine("Cuanto dinero quiere retirar?");
                dRetiro = decimal.Parse(Console.ReadLine(),culture);
                if (dRetiro > Cuentas[cuenRetiro].Monto)
                {
                    Console.WriteLine("No dispone de los fondos suficientes");
                }
                else
                {
                    Cuentas[cuenRetiro].Monto = Cuentas[cuenRetiro].Monto - dRetiro;
                    Console.WriteLine("Retiro exitoso");
                }
            }
            else
            {
                Console.WriteLine("Cuenta no existente, se le redirigira al inicio");
                cuenRetiro = -1;
            }
            return cuenRetiro;
        }
    }
}