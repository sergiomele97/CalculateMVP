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

        public void AddNewPlayers(ref DatosJugadores datosJugadores)
        {
            for (int i = 1; i < nicknames.Length; i++)
            {
                if (datosJugadores.nicks.Contains(nicknames[i]) != true)
                {
                    datosJugadores.nicks.Add(nicknames[i]);
                    datosJugadores.ratingPoints.Add(0);
                }
            }
        }
    }
}
