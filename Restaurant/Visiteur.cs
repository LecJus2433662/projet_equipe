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

        public Visiteur() { }

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
            Temperament temperament = rnd switch
            {
                1 => Temperament.GoodBoy,
                2 => Temperament.BadBoy,
                _ => Temperament.MediumBoy,
            };

            Visiteur visiteur = new Visiteur();
            visiteur.temperament = temperament;
            visiteur.CreerNom();
            return visiteur;
        }

        public override string ToString()
        {
            return $"	{prenom,-10} {nom,-10} - {temperament}\n";
        }
    }
}
