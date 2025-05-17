using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Resto
    {
        float Total { get; set; }
        bool end;
        Plat IngredientsPourPlat;

        Menu menu;
        Plat spaghetti;
        Plat omelette;
        Plat clubSandwich;




        public Resto()
        {
            menu = new Menu("Menu chez resto");
            IngredientsPourPlat = new Plat("");
            spaghetti = new Plat("Spaghetti");
            omelette = new Plat("Omelette");
            clubSandwich = new Plat("Club Sandwich");
            AfficherMenu();













        }
        void AfficherMenu()
        {
            menu.AjouterPlat(omelette);
            omelette.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[2]);
            omelette.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[2]);
            omelette.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[2]);
            omelette.PrixAchat = omelette.CalculerVente();


            menu.AjouterPlat(spaghetti);
            spaghetti.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[15]);
            spaghetti.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[10]);
            spaghetti.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[13]);
            spaghetti.PrixAchat = spaghetti.CalculerVente();

            menu.AjouterPlat(clubSandwich);
            clubSandwich.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[17]);
            clubSandwich.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[18]);
            clubSandwich.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[12]);
            clubSandwich.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[10]);
            clubSandwich.PrixAchat = clubSandwich.CalculerVente();

            Total = 1000;
            end = true;
            Console.WriteLine("Appuyer sur ENTER pour afficher votre menu");
            Console.ReadLine();
            Console.Clear();

            while (end)
            {
                Console.Clear();
                Console.WriteLine("1: afficher menu basique");
                Console.WriteLine("2: afficher status restaurant");
                Console.WriteLine("3: acheter nouveau plat");
                Console.WriteLine("4: commander ingrediant");
                Console.WriteLine("5: info clients");
                Console.WriteLine("6: servir clients");
                Console.WriteLine("7: finir la journée");
                Console.WriteLine("0: Mystère ???");

                string choix = Console.ReadLine();


                switch (choix)
                {

                    case "1":
                        Console.WriteLine(menu);
                        Thread.Sleep(5000);
                        break;
                    case "2":
                        Console.WriteLine(menu);
                        Console.WriteLine($"Vous avez un total de : {Total:f2}$");
                        Thread.Sleep(5000);
                        break;
                    case "3":
                        Console.WriteLine("Quelle est le nom du plat que vous voulez acheter?");
                        string plat = Console.ReadLine();
                        Plat nouveauPlat = new Plat(plat);
                        while (true)
                        {
                            Console.WriteLine($"Quelle ingrédiant voulez-vous dans le plat? appuyer sur 0 pour finir le plat");
                            Console.WriteLine(IngredientsPourPlat.InfoIngrediantDispo());

                            int.TryParse(Console.ReadLine(), out int choice);
                            if (choice == 0)
                            {
                                break;
                            }
                            if (choice >= 1 && choice <= 20)
                            {
                                Console.WriteLine($"combien de {IngredientsPourPlat.ingrediantDispo[choice - 1]} voulez-vous avoir?");
                                int.TryParse(Console.ReadLine(), out int nbIngrediant);
                                for (int i = 0; i < nbIngrediant; i++)
                                {
                                    nouveauPlat.ingredientsPlat.Add(nouveauPlat.ingrediantDispo[choice - 1]);
                                }
                               
                            }
                            if (choice > 20)
                            {
                                Console.WriteLine("Ce n'est pas un ingrédient ");
                            }
                            nouveauPlat.PrixAchat = nouveauPlat.CalculerVente();
                            menu.AjouterPlat(nouveauPlat);
                        }


                        break;
                    case "4":
                        bool AssezArgent = true;
                        Console.WriteLine("voici la liste des ingrédients disponible:");
                        while (AssezArgent)
                        {
                            Console.WriteLine($"total argent :{Total:f2}");
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
                                    if (Total >= IngredientsPourPlat.ingrediantDispo[choice - 1].PrixAchat)
                                    {
                                        Total -= IngredientsPourPlat.ingrediantDispo[choice - 1].PrixAchat;
                                        IngredientsPourPlat.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[choice - 1]);
                                    }

                                }
                                if (Total < IngredientsPourPlat.ingrediantDispo[choice - 1].PrixAchat)
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

                    case "5":
                        break;
                    case "6":

                        break;
                    case "7":
                        Console.WriteLine("fin de la journée");
                        end = false;
                        break;
                    case "0":
                        EmployerMystere();
                        Thread.Sleep(5000);
                        break;

                }
            }
            void EmployerMystere()
            {
                Console.WriteLine("************************************  Employer Mystère  ****************************************************\n");
                Console.WriteLine("Appuyer sur ENTER pour faire apparaitre votre employer");
                Console.ReadLine();
                EngagerEmployer employer = new EngagerEmployer("M.Bernard");
                Console.WriteLine(employer);
            }

        }
    }
}
