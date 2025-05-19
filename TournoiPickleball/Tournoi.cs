using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournoiPickleball
{
    public class Tournoi
    {
        private Equipe equipeEleves;
        private Equipe equipeProfs;
        private List<Joueur> tousLesJoueurs;

        public Tournoi()
        {
            tousLesJoueurs = new List<Joueur>();
            CreerEquipes();
            AfficherMenu();
        }

        void CreerEquipes()
        {
            Joueur eleve1 = new Joueur(NomAleatoire.GetNomComplet(), TypeJoueur.Eleve, GetRaquetteAleatoire());
            Joueur eleve2 = new Joueur(NomAleatoire.GetNomComplet(), TypeJoueur.Eleve, GetRaquetteAleatoire());
            equipeEleves = new Equipe("Équipe des Élèves", eleve1, eleve2);

            Joueur prof1 = new Joueur(NomAleatoire.GetNomComplet(), TypeJoueur.Prof, GetRaquetteAleatoire());
            Joueur prof2 = new Joueur(NomAleatoire.GetNomComplet(), TypeJoueur.Prof, GetRaquetteAleatoire());
            equipeProfs = new Equipe("Équipe des Profs", prof1, prof2);

            tousLesJoueurs.AddRange(new[] { eleve1, eleve2, prof1, prof2 });
        }

        Raquette GetRaquetteAleatoire()
        {
            Random rand = new Random();
            int choix = rand.Next(0, 2);
            if (choix == 0)
            {
                return new RaquetteWilson();
            }
            else
            {
                return new RaquetteCool();
            }
        }

        void AfficherMenu()
        {
            bool continuer = true;

            while (continuer)
            {
                Console.Clear();
                Console.WriteLine("===== Tournoi de Pickleball Prof vs Élèves =====");
                Console.WriteLine("1. Afficher les équipes");
                Console.WriteLine("2. Afficher les statistiques des joueurs");
                Console.WriteLine("3. Lancer un match");
                Console.WriteLine("4. Afficher le classement des joueurs (XP)");
                Console.WriteLine("5. Afficher le classement des joueurs (Niveau)");
                Console.WriteLine("0. Quitter");
                Console.Write("Votre choix : ");
                string choix = Console.ReadLine();

                Console.Clear();

                switch (choix)
                {
                    case "1":
                        equipeEleves.AfficherStats();
                        equipeProfs.AfficherStats();
                        Console.ReadKey();
                        break;

                    case "2":
                        foreach (Joueur joueur in tousLesJoueurs)
                        {
                            joueur.AfficherStatistiques();
                        }
                        Console.ReadKey();
                        break;

                    case "3":
                        Equipe.JouerContre(equipeEleves, equipeProfs);
                        Console.ReadKey();
                        break;

                    case "4":
                        AfficherClassementJoueurs();
                        Console.ReadKey();
                        break;

                    case "5":
                        AfficherClassementParNiveau();
                        Console.ReadKey();
                        break;

                    case "0":
                        Console.WriteLine("Merci d'avoir joué !");
                        continuer = false;
                        break;

                    default:
                        Console.WriteLine("Choix invalide.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        void AfficherClassementParNiveau()
        {
            Console.WriteLine("===== Classement des joueurs par niveau =====\n");

            List<Joueur> joueursTries = tousLesJoueurs.OrderByDescending(joueur => joueur.Niveau).ThenByDescending(joueur => joueur.Experience).ToList();
            int rang = 1;

            foreach (Joueur joueur in joueursTries)
            {
                Console.WriteLine($"{rang}. {joueur.Nom,-20} | Niveau : {joueur.Niveau,-2} | Expérience : {joueur.Experience} XP");
                rang++;
            }
        }

        void AfficherClassementJoueurs()
        {
            Console.WriteLine("Classement des joueurs par expérience :\n");

            List<Joueur> classement = tousLesJoueurs.OrderByDescending(joueurs => joueurs.Experience).ThenBy(joueurs => joueurs.Nom).ToList();

            int position = 1;
            foreach (Joueur joueur in classement)
            {
                Console.WriteLine($"{position}. {joueur.Nom} - {joueur.Experience} XP");
                position++;
            }
        }
    }
}
