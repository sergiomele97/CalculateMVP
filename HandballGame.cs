using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateMVP
{
    internal class HandballGame : Game
    {
        int[] goalsMade;
        int[] goalsReceived;


        public void addScoredPoints(ref DatosJugadores datosJugadores)
        {
            for (int i = 1; i < nicknames.Length; i++)
            {
                int index = datosJugadores.nicks.IndexOf(nicknames[i]);
                datosJugadores.ratingPoints[index] += calculateScoredPoints(i);
            }
        }

        public int calculateScoredPoints(int i)
        {
            int ratingPoints = 0;

            switch (positions[i])
            {

                case 'G':   // Goalkeeper
                    ratingPoints = 50 + 5 * goalsMade[i] - 2 * goalsReceived[i];
                    break;

                case 'F':   // Field Player
                    ratingPoints = 20 + 1 * goalsMade[i] - 1 * goalsReceived[i];
                    break;

            }

            return ratingPoints;
        }

        public HandballGame(string[] partido)
        {
            players = new string[partido.Length];   // Inicializamos los arrays con el tamaño del archivo
            nicknames = new string[partido.Length];
            numbers = new int[partido.Length];
            teamNames = new string[partido.Length];
            positions = new char[partido.Length];
            goalsMade = new int[partido.Length];    
            goalsReceived = new int[partido.Length];


            for (int i = 1; i < partido.Length; i++)    // Iteramos sobre cada linea del archivo
            {
                string[] contenido = partido[i].Split(';');

                players[i] = contenido[0];              // El primer valor [0] de cada array queda sin inicializar
                nicknames[i] = contenido[1];
                numbers[i] = Convert.ToInt32(contenido[2]);
                teamNames[i] = contenido[3];
                positions[i] = Convert.ToChar(contenido[4]);
                goalsMade[i] = Convert.ToInt32(contenido[5]);
                goalsReceived[i] = Convert.ToInt32(contenido[6]);

            }
        }
    }
}
