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

    public class Joueur
    {
        string nom {  get; }
        int force {  get; set; }
        int dexterite {  get; set; }
        NiveauExperience NiveauExperience { get; set; }
        Random Random { get; set; }

        public Joueur(int force, int dexterite)
        {
            this.force = force;
            this.dexterite = dexterite;
            Random = new Random();
        }
        public Joueur()
        {
            int rando = Random.Next(1,4);

            switch (rando)
            {
                case 1:
                    NiveauExperience = NiveauExperience.debutant;
                    force = Random.Next(1,4);

                    break;
                    case 2:
                    NiveauExperience = NiveauExperience.intermediaire;
                    break;
                    case 3:
                    NiveauExperience = NiveauExperience.professionnel;
                    break;
            }
        }

    }
}
