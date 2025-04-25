using System;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int nbRandom = rnd.Next(6, 11);
            for (int i = 0; i < nbRandom; i++)
            {
                Visiteur visiteur = Visiteur.CreerVisiteurAleatoire();
                Console.WriteLine(visiteur);

            }
            
        }
    }
}
