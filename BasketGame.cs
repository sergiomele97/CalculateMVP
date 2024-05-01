using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateMVP
{
    internal class BasketGame : Game
    {
        int[] scoredPoints;
        int[] rebounds;
        int[] assists;


        public void addScoredPoints(ref Puntuaciones puntuaciones)
        {
            for (int i = 1; i < nicknames.Length; i++)
            {
                int index = puntuaciones.nicks.IndexOf(nicknames[i]);
                puntuaciones.ratingPoints[index] += calculateScoredPoints(i);
            }
        }

        public int calculateScoredPoints(int i)
        {
            int ratingPoints = 0;

            switch (positions[i]){

                case 'G':   // Guard
                    ratingPoints = 2 * scoredPoints[i] + 3 * rebounds[i] + 1 * assists[i];
                    break;

                case 'F':   // Forward
                    ratingPoints = 2 * scoredPoints[i] + 2 * rebounds[i] + 2 * assists[i];
                    break;

                case 'C':   // Center
                    ratingPoints = 2 * scoredPoints[i] + 1 * rebounds[i] + 3 * assists[i];
                    break;

            }

            return ratingPoints;
        }

        public BasketGame(string[] partido) 
        {
            players = new string[partido.Length];               // Establecemos tamaño de los arrays
            nicknames = new string[partido.Length];
            numbers = new int[partido.Length];
            teamNames = new string[partido.Length];
            positions = new char[partido.Length];
            scoredPoints = new int[partido.Length];
            rebounds = new int[partido.Length];
            assists = new int[partido.Length];

            for (int i = 1; i < partido.Length; i++)            // Iteramos sobre cada linea del archivo
            {
                string[] contenido = partido[i].Split(';');

                players[i] = contenido[0];                      // El primer valor [0] de cada array queda sin inicializar
                nicknames[i] = contenido[1]; 
                numbers[i] = Convert.ToInt32(contenido[2]); 
                teamNames[i] = contenido[3]; 
                positions[i] = Convert.ToChar(contenido[4]);
                scoredPoints[i] = Convert.ToInt32(contenido[5]);
                rebounds[i] = Convert.ToInt32(contenido[6]);
                assists[i] = Convert.ToInt32(contenido[7]);
            }
        }

        
    }    
}
