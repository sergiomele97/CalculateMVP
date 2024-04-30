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


        public BasketGame(string[] partido)
        {
            for (int i = 1; i < partido.Length; i++)    // Iteramos sobre cada linea del archivo
            {
                string[] contenido = partido[i].Split(';');

                players[i] = contenido[0];              // El primer valor [0] de cada array queda sin inicializar
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
