using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournoiPickleball
{

    public enum TypeJoueur
    {
        Eleve,
        Prof
    }

    public class Joueur
    {
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



        public int Niveau
        {
            get { return Experience / 50; }
        }
        public override string ToString()
        {
            string info = "";
            info = $"\n{Nom} ({Type})\n";
            info += $"Niveau : {Niveau}\n";
            info += $"Expérience : {Experience}\n";
            info += $"Aura : {Aura} \n";
            info +=  Raquette + "\n";
            return info;
        }


    }
}
