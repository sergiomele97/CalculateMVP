

namespace CalculateMVP
{
    internal class Game
    {
        public string[] players;
        public string[] nicknames;
        public int[] numbers;
        public string[] teamNames;
        public char[] positions;

        public string winnerTeam;


        public void AddNewPlayers(ref Puntuaciones puntuaciones)    // Metodo comun para todas las clases hijas
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
