using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalculateMVP
{
    internal class Game
    {
        public string[] players;
        public string[] nicknames;
        public int[] numbers;
        public string[] teamNames;
        public char[] positions;


        public void AddNewPlayers(ref Puntuaciones puntuaciones)
        {
            for (int i = 1; i < nicknames.Length; i++)
            {
                if (puntuaciones.nicks.Contains(nicknames[i]) != true)
                {
                    puntuaciones.nicks.Add(nicknames[i]);
                    puntuaciones.ratingPoints.Add(0);
                }
            }
        }
    }
}
