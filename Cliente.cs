using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cajero
{
    class Cliente
    {      
        public void Leer(string cuenta)
        {
            StreamReader sr = new StreamReader(@"F:\CodiGo\Scrum\BD.txt");
            string[] datos = new string[6];
            string cadena;
            int monto;
            char separador = ',';
            int i = 0;

            cadena = sr.ReadLine();
            Console.WriteLine(cadena);
            while (cadena != null)
            {
                datos = cadena.Split(separador);
                Console.WriteLine(datos[3]);
                string valorI = Convert.ToString(datos[3]);
                Console.ReadKey();
                i++;
                if (valorI == cuenta)
                {
                    Console.WriteLine($"monto: {datos[4]}");
                    Console.WriteLine($"cantidad a depositar a {datos[4]}");
                    int z = Convert.ToInt32(datos[4]);
                    monto = Convert.ToInt32(Console.ReadLine());
                    z = z  + monto;
                    Console.WriteLine(z);
                }         
            }
            Console.ReadKey();
        }

        public void Depositar(int monto)
        {
            StreamWriter sw = new StreamWriter(@"F:\CodiGo\Scrum\dsa.txt");
          

        }
    }
}
