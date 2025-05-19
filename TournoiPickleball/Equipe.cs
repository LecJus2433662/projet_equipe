using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournoiPickleball
{
    public class Equipe
    {
        public string NomEquipe { get; private set; }
        public Joueur Joueur1 { get; private set; }
        public Joueur Joueur2 { get; private set; }
        public int Score { get; private set; }

        public Equipe(string nomEquipe, Joueur joueur1, Joueur joueur2)
        {
            NomEquipe = nomEquipe;
            Joueur1 = joueur1;
            Joueur2 = joueur2;
            Score = 0;
        }

        public void ReinitialiserScore()
        {
            Score = 0;
        }

        public void AjouterPoint()
        {
            Score++;
        }

        public void AfficherStats()
        {
            Console.WriteLine($"--- {NomEquipe} ---");
            Console.WriteLine(Joueur1);
            Console.WriteLine(Joueur2);
        }

        public void RecompenseGagnants()
        {
            Joueur1.GagnerExperience(10);
            Joueur2.GagnerExperience(10);
            Joueur1.GagnerAura(5);
            Joueur2.GagnerAura(5);
        }

        public static Equipe JouerContre(Equipe equipe1, Equipe equipe2)
        {
            Console.WriteLine($"Match entre {equipe1.NomEquipe} et {equipe2.NomEquipe} !");
            equipe1.ReinitialiserScore();
            equipe2.ReinitialiserScore();

            Random rand = new Random();

            while (equipe1.Score < 15 && equipe2.Score < 15)
            {
                int point = rand.Next(0, 2);
                if (point == 0)
                {
                    equipe1.AjouterPoint();
                }
                else
                {
                    equipe2.AjouterPoint();
                }
            }

            Console.WriteLine($"{equipe1.NomEquipe} : {equipe1.Score} points");
            Console.WriteLine($"{equipe2.NomEquipe} : {equipe2.Score} points");

            Equipe gagnante;

            if (equipe1.Score == 15)
            {
                gagnante = equipe1;
            }
            else
            {
                gagnante = equipe2;
            }

            Console.WriteLine($"L'équipe gagnante est : {gagnante.NomEquipe} !");
            
            gagnante.RecompenseGagnants();

            gagnante.Joueur1.Raquette.UserRaquette(10);
            gagnante.Joueur2.Raquette.UserRaquette(10);

            return gagnante;
        }
        public override string ToString()
        {
            string info = "";
            info = $"--- {NomEquipe} ---\n";
            info += Joueur1;
            info += Joueur2;
            return info;
        }
    }
}
