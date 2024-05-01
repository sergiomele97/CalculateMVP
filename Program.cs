using System;
using System.IO;
using System.Linq;


namespace CalculateMVP
{
    internal class Program
    {
        public static Puntuaciones puntuaciones = new Puntuaciones();                           // Creamos una instancia para guardar las puntuaciones

        static void Main(string[] args)
        {
            string directorio; 
            string[] archivos = {}; 
            

            while (IsDirectoryOK(directorio = SolicitarDirectorio(), ref archivos) != true)     // 1. Bucle hasta obtener un directorio adecuado
            {
                Console.WriteLine("El directorio introducido no cumple con las condiciones");   
            }

            GameDataProcessing(archivos);                                                       // 2. Procesa los archivos y almacena la información en la instancia puntuaciones (Nicks + ratingPoints)                        

            Console.WriteLine(FindMVP(directorio, archivos));                                   // 3. Mostramos por pantalla los resultados de calcular el MVP para ese directorio
        
        }   // FIN DEL PROGRAMA



        //-----ESPACIO-PARA-METODOS-------------------------------------------------------------------------------------------------------------------

        /*
         *  1. OBTENCION DEL DIRECTORIO
         */

        internal static string SolicitarDirectorio()
        {
            Console.WriteLine("Introduzca la ruta absoluta al directorio con los archivos de partidos:");
            string directorio = Console.ReadLine();

            return directorio;
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

                    foreach (string archivo in archivos)     
                    {
                        Console.WriteLine(archivo);
                    }
                    
                }
            } catch (Exception e) { Console.WriteLine(e.Message); return false; }
            
            return true;
        }


        /*
         * 2. PROCESAMIENTO DE ARCHIVOS EN EL DIRECTORIO ACEPTADO
         */

        private static void GameDataProcessing(string[] archivos)
        {
            
            foreach (string archivo in archivos)
            {
                if (IsGameProcessingOK(archivo) != true)
                {
                    Console.WriteLine("Detectado archivo con formato invalido: " + archivo +
                                      "\nNo se puede calcular el MVP si un archivo esta comprometido.\n" +
                                      "El programa se cerrará.");
                    Console.ReadKey();
                    System.Environment.Exit(0);     // Si un archivo es NOK --> Finaliza el programa
                };
            }
        }


        internal static bool IsGameProcessingOK(string archivo)
        {
            try
            {
                string[] partido = File.ReadAllLines(archivo);      // Guardamos archivo en un String[]
                string deporte = partido[0];                        // Consultamos primera linea para saber el deporte

                switch (deporte)
                {
                    case "BASKETBALL":
                        BasketGame basketGame = new BasketGame(partido);        // Crea instancia partido
                        basketGame.AddNewPlayers(ref puntuaciones);             // Añade Jugadores nuevos
                        basketGame.addScoredPoints(ref puntuaciones);           // Calcula puntuaciones y las añade
                        break;

                    case "HANDBALL":
                        HandballGame handballGame = new HandballGame(partido);
                        handballGame.AddNewPlayers(ref puntuaciones);
                        handballGame.addScoredPoints(ref puntuaciones);
                        break;

                    default:
                        Console.WriteLine("Detectado archivo con formato invalido: " + archivo +
                                          "\nNo se puede calcular el MVP si un archivo esta comprometido");
                        return false;
                } 
            }
            catch (Exception e) { Console.WriteLine(e.Message); return false; }

            return true;
        }


        /*
         * 3. BUSQUEDA DEL JUGADOR CON EL VALOR MAXIMO DE RATING POINTS 
         */

        internal static string FindMVP(string directorio, string[] archivos)
        {

            int indexMVP = 0;
            for (int i = 0; i < puntuaciones.nicks.Count(); i++)
            {
                Console.WriteLine("El jugador es: " + puntuaciones.nicks[i] + ", con una puntuacion de " + puntuaciones.ratingPoints[i] + "."); 
                if (puntuaciones.ratingPoints[i] > puntuaciones.ratingPoints[indexMVP])
                {
                    indexMVP = i;
                }
            }

            return "\nEl jugador MVP es: " + puntuaciones.nicks[indexMVP] + ", con una puntuacion de " + puntuaciones.ratingPoints[indexMVP] + ".\n";
        }
    }
}
