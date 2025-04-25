using System;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Menu platMatin = new Menu("Menu du matin", 5);

            Console.WriteLine("Appuyer sur ENTER pour afficher votre menu");
            Console.WriteLine("*********************************** MATIN  *************************************************");
            Console.WriteLine($"{platMatin}\n");
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
