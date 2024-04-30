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
            string[] archivos = {};

            while (IsDirectoryOK(directorio = SolicitarDirectorio(), ref archivos) != true)   // Bucle hasta obtener un directorio adecuado
            {
                Console.WriteLine("El directorio introducido no cumple con las condiciones");   
            }

            Console.WriteLine(CalcularMVP(directorio, archivos));         // Mostramos por pantalla los resultados de calcular el MVP para ese directorio
        
        }


        internal static bool IsDirectoryOK(string directorio, ref string[] archivos)
        {
            Console.Clear();

            try
            {
                archivos = Directory.GetFiles(directorio, "*.txt");    // Obtiene array de Strings con las rutas absolutas de los archivos

                if (archivos.Length == 0) { Console.WriteLine("El directorio no contiene archivos con el formato esperado"); return false; }
                else
                {
                    Console.WriteLine("Partidos encontrados:");
                    foreach (string archivo in archivos)     // Debug
                    {
                        Console.WriteLine(archivo);
                    }
                }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
            
            return true;
        }


        internal static string SolicitarDirectorio()
        {
            Console.WriteLine("Introduzca la ruta absoluta al directorio con los archivos de partidos:");
            string directorio = Console.ReadLine();

            return directorio;
        }


        internal static bool ProcesarPartido(string archivo)
        {
            string[] partido = File.ReadAllLines(archivo);
            string deporte = partido[0];

            switch (deporte)
            {
                case "BASKETBALL":
                    BasketGame basketGame = new BasketGame(partido);
                    break;

                case "HANDBALL":
                    break;

                default:
                    break;
            }

            return true;
        }


        internal static string CalcularMVP(string directorio, string[] archivos)
        {

            foreach (string archivo in archivos)     
            {
                ProcesarPartido(archivo);
            }
            return "";
        }
    }
}
