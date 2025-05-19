using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournoiPickleball
{
    public enum NiveauExperience
    {
        debutant,
        intermediaire,
        professionnel 
    }
    public enum TypeJoueur
    {
        Eleve,
        Prof
    }

    public class Joueur
    {
        string nom {  get; }
        int force {  get; set; }
        int dexterite {  get; set; }
        NiveauExperience NiveauExperience { get; set; }
        Random Random { get; set; }

        
        public string Nom { get; private set; }
        public TypeJoueur Type { get; private set; }
        public int Experience { get; private set; }
        public int Aura { get; private set; }
        public Raquette Raquette { get; private set; }

        public Joueur(string nom, TypeJoueur type, Raquette raquette)
        {
            Nom = nom;
            Type = type;
            Raquette = raquette;
            Experience = 0;
            Aura = 0;
        }

        public void GagnerExperience(int xp)
        {
            Experience += xp;
        }

        public void GagnerAura(int points)
        {
            Aura += points;
        }

        public void AfficherStatistiques()
        {
            Console.WriteLine($"{Nom} ({Type})");
            Console.WriteLine($"→ Niveau : {Niveau}");
            Console.WriteLine($"→ Expérience : {Experience}");
            Console.WriteLine($"→ Aura : {Aura}");
            Raquette.AfficherEtat();
            Console.WriteLine();
        }

        public int Niveau
        {
            get { return Experience / 50; }
        }

       

    }
}
