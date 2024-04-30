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
        public static DatosJugadores datosJugadores = new DatosJugadores();  // Instancia para guardar datos de los jugadores

        static void Main(string[] args)
        {
            string directorio; 
            string[] archivos = {};
            

            while (IsDirectoryOK(directorio = SolicitarDirectorio(), ref archivos) != true)   // Bucle hasta obtener un directorio adecuado
            {
                Console.WriteLine("El directorio introducido no cumple con las condiciones");   
            }

            Console.WriteLine(FindMVP(directorio, archivos));         // Mostramos por pantalla los resultados de calcular el MVP para ese directorio
        
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


        internal static bool IsGameProcessingOK(string archivo)
        {
            string[] partido = File.ReadAllLines(archivo);      // Guardamos archivo en un String[]
            string deporte = partido[0];                        // Consultamos primera linea para saber el deporte
            Console.WriteLine(deporte); // debug

            switch (deporte)
            {
                case "BASKETBALL":
                    BasketGame basketGame = new BasketGame(partido);    // Crea instancia partido
                    basketGame.AddNewPlayers(ref datosJugadores);       // Añade Jugadores nuevos
                    basketGame.addScoredPoints(ref datosJugadores);     // Calcula puntuaciones y las añade
                    break;

                case "HANDBALL":
                    HandballGame handballGame = new HandballGame(partido);
                    handballGame.AddNewPlayers(ref datosJugadores);
                    handballGame.addScoredPoints(ref datosJugadores);
                    break;

                default:
                    Console.WriteLine("Detectado archivo con formato invalido: " + archivo + 
                                      "\nNo se puede calcular el MVP si un archivo esta comprometido");
                    return false;
            }

            return true;
        }


        internal static string FindMVP(string directorio, string[] archivos)
        {
            // Game processing
            foreach (string archivo in archivos)     
            {
                IsGameProcessingOK(archivo);
            }

            int indexMVP = 0;

            for (int i = 0; i < datosJugadores.nicks.Count(); i++)
            {
                if (datosJugadores.ratingPoints[i] > datosJugadores.ratingPoints[indexMVP])
                {
                    indexMVP = i;
                }
            }


            return "El jugador MVP es: " + datosJugadores.nicks[indexMVP] + ", con una puntuacion de " + datosJugadores.ratingPoints[indexMVP] + ".";
        }
    }
}
