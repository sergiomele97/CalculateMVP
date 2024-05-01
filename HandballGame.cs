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


        public void addScoredPoints(ref Puntuaciones puntuaciones)
        {
            for (int i = 1; i < nicknames.Length; i++)
            {
                int index = puntuaciones.nicks.IndexOf(nicknames[i]);           // Busca el indice del nick en puntuaciones
                puntuaciones.ratingPoints[index] += calculateScoredPoints(i);   // Modifica los rating points en ese indice
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

            if (teamNames[i] == winnerTeam)     // Bonus por equipo ganador
            {
                ratingPoints += 10;
            }

            return ratingPoints;
        }


        public string setWinnerTeam()
        {
            string[] equipos = teamNames.Distinct().ToArray();      // Crear array con nombres equipos unicos
            int[] puntuacionEquipos = new int[equipos.Length];

            for (int i = 1; i < teamNames.Length; i++)              // Sumamos los puntos a cada equipo correspondiente
            {
                puntuacionEquipos[Array.IndexOf(equipos, teamNames[i])] += goalsMade[i];
            }

            return equipos[Array.IndexOf(puntuacionEquipos, puntuacionEquipos.Max())];  // Devolvemos resultado
        }


        public HandballGame(string[] partido)
        {
            players = new string[partido.Length];           // Inicializamos los arrays con el tamaño del archivo
            nicknames = new string[partido.Length];
            numbers = new int[partido.Length];
            teamNames = new string[partido.Length];
            positions = new char[partido.Length];
            goalsMade = new int[partido.Length];    
            goalsReceived = new int[partido.Length];


            for (int i = 1; i < partido.Length; i++)        // Iteramos sobre cada linea del archivo menos las primera (deporte)
            {
                string[] contenido = partido[i].Split(';');

                players[i] = contenido[0];                  // El primer valor [0] de cada array queda sin asignar valor
                nicknames[i] = contenido[1];
                numbers[i] = Convert.ToInt32(contenido[2]);
                teamNames[i] = contenido[3];
                positions[i] = Convert.ToChar(contenido[4]);
                goalsMade[i] = Convert.ToInt32(contenido[5]);
                goalsReceived[i] = Convert.ToInt32(contenido[6]);

            }

            winnerTeam = setWinnerTeam();                   // Asignamos valor al equipo ganador
        }
    }
}
