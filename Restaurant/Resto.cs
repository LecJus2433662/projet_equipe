using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Resto
    {
        int total { get; set; }



        public Resto()
        {
            // metre tout ça dans une fonction
            total = 10000;
            Plat platMatin = new Plat("Menu du matin", 5);

            Console.WriteLine("Appuyer sur ENTER pour afficher votre menu");
            Console.ReadLine();
            Console.Clear();
            // alexis fait 1,2,6 pi les autre on les fait ensemble
            Console.WriteLine("1: afficher menu");
            Console.WriteLine("2: afficher status restaurant");
            Console.WriteLine("3: ajuster menu");
            Console.WriteLine("4: acheter nouveau plat");
            Console.WriteLine("5: commander ingrediant");
            Console.WriteLine("6: info clients");
            Console.WriteLine("7: servir clients");
            Console.WriteLine($"{platMatin}\n");
            Random rnd = new Random();
            int nbRandom = rnd.Next(6, 11);
            Console.WriteLine();
           
            Menu menu = new Menu();
            Plat plat = new Plat("",34);
            Console.WriteLine(plat.InfoIngrediantDispo());

            Console.WriteLine("************************************  Employer Mystère  ****************************************************");
            Console.WriteLine("Appuyer sur ENTER pour faire apparaitre votre employer");
            Console.ReadLine();
            EngagerEmployer employer = new EngagerEmployer("M.Bernard");
            Console.WriteLine(employer);
            Console.WriteLine("************************************  Employer Mystère  ****************************************************");



        }





    }
}
