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
        string[] datos = new string[6];
        List<string> lista = new List<string>() { };
        
        public void Leer(string dni)
        {
            StreamReader sr = new StreamReader(@"F:\CodiGo\Scrum\BD.txt");
            
            string cadena;
            int count = 0;
            char separador = ',';
            string estado = false;

            while (!sr.EndOfStream)
            {
                cadena = sr.ReadLine();
                lista.Add(cadena);

                while (cadena != null)
                {
                    count = count + 1;
                    datos = cadena.Split(separador);

                    if (datos[0].Trim().Equals(dni))
                    {
                        Console.WriteLine(count);
                        estado = true;
                        break;
                    }
                    cadena = sr.ReadLine();
                }
            }

            if(estado == true)
            {
                file.delete("exension...");
                Depositar();
            }
            
            Console.ReadKey();
        }
}

        //public void Depositar()
        //{
        //    using (StreamWriter sw = new StreamWriter(@"F:\CodiGo\Scrum\BD.txt"))
        //    {
        //        foreach (string x in lista)
        //        {
        //            sw.Write(x);
        //        }
        //    }     
        //}
    
}
