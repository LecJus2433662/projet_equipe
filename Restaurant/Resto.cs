using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Resto
    {
        float total { get; set; }
        bool end;
        Plat IngredientsPourPlat = new Plat("");

        Menu menuBasique = new Menu();
        Plat spaghetti = new Plat("Spaghetti");
        Plat omelette = new Plat("Omelette");
        Plat clubSandwich = new Plat("Club Sandwich");

        Menu menuFancy = new Menu();
        Plat wagyu = new Plat("Wagyu Beef Aux Poivre");
        Plat soupeRequin = new Plat("Soupe Au Requin Blanc");
        Plat pouletAuBeurre = new Plat("Poulet Au Beurre");
        public Resto()
        {
            menuBasique.AjouterPlat(omelette);
            menuBasique.AjouterPlat(spaghetti);
            menuBasique.AjouterPlat(clubSandwich);

            menuFancy.AjouterPlat(wagyu);
            menuFancy.AjouterPlat(soupeRequin);
            menuFancy.AjouterPlat(pouletAuBeurre);
            // metre tout ça dans une fonction
            total = 1000;
            end = true;
            Console.WriteLine("Appuyer sur ENTER pour afficher votre menu");
            Console.ReadLine();
            Console.Clear();
            // alexis fait 1,2,6 pi les autre on les fait ensemble
            while (end)
            {
                Console.Clear();
                Console.WriteLine("1: afficher menu");
                Console.WriteLine("2: afficher status restaurant");
                Console.WriteLine("3: ajuster menu");
                Console.WriteLine("4: acheter nouveau plat");
                Console.WriteLine("5: commander ingrediant");
                Console.WriteLine("6: info clients");
                Console.WriteLine("7: servir clients");
                Console.WriteLine("8: finir la journée");
                string choix = Console.ReadLine();


                switch (choix)
                {

                    case "1":
                        int isdfs = 0;
                        foreach (Ingredient ingredient in IngredientsPourPlat.ingredientsPlat)
                        {
                            isdfs++;
                        }
                        Console.WriteLine(isdfs);
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        bool AssezArgent = true;
                        Console.WriteLine("voici la liste des ingrédients disponible:");
                        while (AssezArgent)
                        {
                            Console.WriteLine($"total argent :{total}");
                            Console.WriteLine(IngredientsPourPlat.InfoIngrediantDispo());
                            Console.WriteLine("Quel ingrédient voulez-vous acheter? appuyer sur 0 pour quitter");
                            int.TryParse(Console.ReadLine(), out int choice);
                            if (choice == 0)
                            {
                                break;
                            }
                            if (choice >= 1 && choice <= 20)
                            {
                                Console.WriteLine($"combien de {IngredientsPourPlat.ingrediantDispo[choice - 1]} voulez-vous acheter?");
                                int.TryParse(Console.ReadLine(), out int achat);
                                for (int i = 0; i < achat; i++)
                                {
                                    if (total >= IngredientsPourPlat.ingrediantDispo[choice - 1].PrixAchat)
                                    {
                                        total -= IngredientsPourPlat.ingrediantDispo[choice - 1].PrixAchat;
                                        IngredientsPourPlat.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[choice - 1]);
                                    }

                                }
                                if (total < IngredientsPourPlat.ingrediantDispo[choice - 1].PrixAchat)
                                {
                                    Console.WriteLine("T trop pauvre pour acheter plus d'ingrédient");
                                }
                            }
                            if (choice > 20)
                            {
                                Console.WriteLine("Ce n'est pas un ingrédient ");
                            }
                        }


                        break;

                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        Console.WriteLine("fin de la journée");
                        end = false;
                        break;


                }
            }





        }





    }
}
