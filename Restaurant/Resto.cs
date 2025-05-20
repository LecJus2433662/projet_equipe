using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        List<Client> clients;
        int reductionEmploye = 0;

        public Resto()
        {
            Visiteur.CreerVisiteurAleatoire();
            menu = new Menu("Menu chez resto");
            IngredientsPourPlat = new Plat("");
            spaghetti = new Plat("Spaghetti");
            omelette = new Plat("Omelette");
            clubSandwich = new Plat("Club Sandwich");
            clients = new List<Client>();
            CreerClients();
            AfficherMenu();
        }

        public void AfficherMenu()
        {
            omelette.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[2]);
            omelette.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[2]);
            omelette.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[12]);
            menu.AjouterPlat(omelette);
            omelette.PrixAchat = omelette.CalculerVente();

            spaghetti.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[15]);
            spaghetti.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[10]);
            spaghetti.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[13]);
            menu.AjouterPlat(spaghetti);
            spaghetti.PrixAchat = spaghetti.CalculerVente();

            clubSandwich.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[17]);
            clubSandwich.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[12]);
            clubSandwich.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[10]);
            clubSandwich.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[13]);
            menu.AjouterPlat(clubSandwich);
            clubSandwich.PrixAchat = clubSandwich.CalculerVente();

            Total = 1000;
            end = false;

            Console.WriteLine("Appuyer sur ENTER pour afficher votre menu");
            Console.ReadLine();
            Console.Clear();

            while (!end)
            {
                Console.Clear();
                Console.WriteLine("1: afficher menu basique");
                Console.WriteLine("2: afficher status restaurant");
                Console.WriteLine("3: acheter nouveau plat");
                Console.WriteLine("4: commander ingrédient");
                Console.WriteLine("5: info clients");
                Console.WriteLine("6: servir clients");
                Console.WriteLine("7: finir la journée");
                Console.WriteLine("0: Mystère ???");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.WriteLine(menu);
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine(menu);
                        Console.WriteLine($"Vous avez un total de : {Total}$");
                        Console.ReadKey();
                        break;

                    case "3":
                        CreerPlat();
                        break;

                    case "4":
                        AcheterIngredients();
                        break;

                    case "5":
                        InfoClient();
                        break;

                    case "6":
                        ServirClient();
                        break;

                    case "7":
                        Console.WriteLine("Fin de la journée");
                        end = true;
                        break;
                    case "0":
                        EmployerMystere();
                        Console.ReadKey();
                        break;
                }
            }
        }
        void CreerPlat()
        {
            Console.WriteLine("Quel est le nom du plat que vous voulez acheter?");
            string plat = Console.ReadLine();
            Plat nouveauPlat = new Plat(plat);
            bool finAchat = false;
            while (!finAchat)
            {
                Console.WriteLine("Quel ingrédient voulez-vous dans le plat ? Appuyez sur 0 pour finir le plat");
                Console.WriteLine(IngredientsPourPlat.InfoIngrediantDispo());
                int.TryParse(Console.ReadLine(), out int choice);
                if (choice == 0) finAchat = true;
                if (choice >= 1 && choice <= 20)
                {
                    Console.WriteLine($"Combien de {IngredientsPourPlat.ingrediantDispo[choice - 1]} voulez-vous ?");
                    int.TryParse(Console.ReadLine(), out int nbIngrediant);
                    for (int i = 0; i < nbIngrediant; i++)
                    {
                        if (Total > IngredientsPourPlat.ingrediantDispo[choice - 1].PrixAchat)
                        {
                            Total -= IngredientsPourPlat.ingrediantDispo[choice - 1].PrixAchat;
                            nouveauPlat.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[choice - 1]);
                        }
                        else
                        {
                            Console.WriteLine("Trop pauvre pour acheter plus d'ingrédients pour le plat.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ce n'est pas un ingrédient valide.");
                }
            }
            menu.AjouterPlat(nouveauPlat);
            nouveauPlat.PrixAchat = nouveauPlat.CalculerVente();
        }

        void AcheterIngredients()
        {
            bool AssezArgent = true;
            while (AssezArgent)
            {
                Console.WriteLine($"Total argent : {Total:F2}$");
                Console.WriteLine(IngredientsPourPlat.InfoIngrediantDispo());
                Console.WriteLine("Quel ingrédient voulez-vous acheter ? Appuyez sur 0 pour quitter.");
                int.TryParse(Console.ReadLine(), out int choice);
                if (choice == 0) break;
                if (choice >= 1 && choice <= 20)
                {
                    Console.WriteLine($"Combien de {IngredientsPourPlat.ingrediantDispo[choice - 1]} voulez-vous acheter ?");
                    int.TryParse(Console.ReadLine(), out int achat);
                    for (int i = 0; i < achat; i++)
                    {
                        float prixAvecReduction = IngredientsPourPlat.ingrediantDispo[choice - 1].PrixAchat - reductionEmploye;


                        if (prixAvecReduction < 0) prixAvecReduction = 0;

                        if (Total >= prixAvecReduction)
                        {
                            Total -= prixAvecReduction;
                            IngredientsPourPlat.ingredientsPlat.Add(IngredientsPourPlat.ingrediantDispo[choice - 1]);
                        }
                        else
                        {
                            Console.WriteLine("Trop pauvre pour acheter plus d'ingrédients.");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ce n'est pas un ingrédient valide.");
                }
            }
        }

        void ServirClient()
        {
            Console.WriteLine("=== Service des clients ===\n");
            Random rnd = new Random();
            float totalArgentGagne = 0;
            int nbPlatsServis = 0;
            foreach (Client client in clients)
            {
                if (menu.Plats.Count == 0)
                {
                    Console.WriteLine("Aucun plat disponible.");
                    break;
                }

                int indexPlat = rnd.Next(menu.Plats.Count);
                Plat platServi = menu.Plats[indexPlat];
                Console.WriteLine($"Le client {client} reçoit le plat : {platServi.Nom}");
                totalArgentGagne += platServi.PrixAchat;
                nbPlatsServis++;
            }
            Total += totalArgentGagne;
            Console.WriteLine($"\n{nbPlatsServis} plats servis, vous avez gagné {totalArgentGagne:F2}$");
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        }

        void InfoClient()
        {
            int nbClients = 5;
            Console.WriteLine("=== Informations des clients ===\n");
            Console.WriteLine($"Nombre de client : {nbClients}\n");
            foreach (Client client in clients)
            {
                Console.WriteLine(client);
            }
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        }

        void EmployerMystere()
        {
            Console.WriteLine("************************************  Employé Mystère  ****************************************************\n");
            Console.WriteLine("Appuyez sur ENTER pour faire apparaître votre employé");
            Console.ReadLine();
            Employer employer = new Employer("M.Bernard");
            Console.WriteLine(employer);
        }

        void CreerClients()
        {
            int nbClient = 5;
            for (int i = 0; i < nbClient; i++)
            {
                string nomClient = FabriqueNom.GetRandomPrenom() + " " + FabriqueNom.GetRandomNom();
                Client client = new Client(nomClient);
                int nbVisiteurs = new Random().Next(1, 4);
                for (int j = 0; j < nbVisiteurs; j++)
                {

                }
                clients.Add(client);
            }
        }
    }
}
