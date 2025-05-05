using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Resto
    {
        int total {  get; set; }
       
        
        
        public Resto()
        {
            total = 10000;
            Plat platMatin = new Plat("Menu du matin", 5);

            Console.WriteLine("Appuyer sur ENTER pour afficher votre menu");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("*********************************** PLAT  *************************************************");

            Console.WriteLine($"{platMatin}\n");
            Random rnd = new Random();
            int nbRandom = rnd.Next(6, 11);
            Console.WriteLine();
            for (int i = 0; i < nbRandom; i++)
            {
            Client client = new Client();
                Visiteur visiteur = Visiteur.CreerVisiteurAleatoire();
               client.AjouterVisiteur(visiteur);
              
            }
            Menu menu = new Menu();
            Plat plat = new Plat("",34);
            menu.AjouterPlat(plat);
            Console.WriteLine(client);

        }


        


    }
}
