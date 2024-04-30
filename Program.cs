using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateMVP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directorio;

            while (IsDirectoryOK(directorio = SolicitarDirectorio()) != true)   // Bucle hasta obtener un directorio adecuado
            {
                Console.Clear();
                Console.WriteLine("El directorio introducido no cumple con las condiciones");   
            }

            Console.WriteLine(CalcularMVP(directorio));         // Mostramos por pantalla los resultados de calcular el MVP para ese directorio
        
        }

        internal static bool IsDirectoryOK(string directorio)
        {
            string[] archivos = Directory.GetFiles(directorio, "*.txt");    // Obtiene array de Strings con las rutas absolutas de los archivos

            foreach (string archivo in archivos)     // Debug
            {
                Console.WriteLine(archivo);
            }

            return false;
        }

        internal static string SolicitarDirectorio()
        {
            Console.WriteLine("Introduzca la ruta absoluta al directorio con los archivos de partidos:");
            string directorio = Console.ReadLine();

            return directorio;
        }

        internal static bool IsFileOK(string archivo)
        {
            return true;
        }

        internal static string CalcularMVP(string directorio)
        {
            string[] archivos = Directory.GetFiles(directorio, "*.txt");    

            foreach (string archivo in archivos)     
            {
                IsFileOK(archivo);
            }
            return "";
        }
    }
}
