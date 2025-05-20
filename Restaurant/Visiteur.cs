using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Visiteur
    {
        public enum Temperament
        {
            GoodBoy,
            MediumBoy,
            BadBoy
        }

        string nom;
        string prenom;
        Temperament temperament;

        public Visiteur(string nom, string prenom, Temperament temperament)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.temperament = temperament;
        }

        public void CreerNom()
        {
            try
            {
                FabriqueNom.RemplirListe();
                nom = FabriqueNom.GetRandomNom();
                prenom = FabriqueNom.GetRandomPrenom();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }

        public static Visiteur CreerVisiteurAleatoire()
        {
            Random random = new Random();
            int rnd = random.Next(1, 4);
            Temperament temperament;
            switch (rnd)
            {
                case 1:
                    temperament = Temperament.MediumBoy;
                    break;
                case 2:
                    temperament = Temperament.GoodBoy;
                    break;
                case 3:
                    temperament = Temperament.BadBoy;
                    break;
                default:
                    temperament = Temperament.MediumBoy; 
                    break;
            }

            Visiteur visiteur = new Visiteur("", "", temperament); 
            visiteur.CreerNom(); 
            return visiteur;
        }

        public override string ToString()
        {
            return $"    {prenom,-10} {nom,-10} - {temperament}\n";
        }
    }
}
