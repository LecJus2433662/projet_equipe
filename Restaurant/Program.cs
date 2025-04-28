using System;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Plat platMatin = new Plat("Menu du matin", 5);

            Console.WriteLine("Appuyer sur ENTER pour afficher votre menu");
            Console.ReadLine();
            Console.Clear();
            Ingredient tomate = new Ingredient("Tomate",10);
            Ingredient laitue = new Ingredient("Laitue",15);
            Console.WriteLine("*********************************** PLAT  *************************************************");

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
