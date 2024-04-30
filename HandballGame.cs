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
