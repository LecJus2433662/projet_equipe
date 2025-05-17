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
            string[] noms = new string[] { "Labrador", "Vincent", "Francis", "Sophie", "Julien", "Marie", "Alexandre", "Émilie", "Thomas", "Chloé", "Maxime", "Léa", "Gabriel", "Camille", "Lucas", "Amélie", "Hugo", "Sarah", "Mathieu", "Clara" };
           
            nom = noms[Random.Next(noms.Length)];

            switch (rando)
            {
                case 1:
                    NiveauExperience = NiveauExperience.debutant;
                    force = Random.Next(1,4);
                    dexterite = Random.Next(1,4);

                    break;
                    case 2:
                    NiveauExperience = NiveauExperience.intermediaire;
                    force = Random.Next(2, 8);
                    dexterite = Random.Next(2, 8);
                    break;
                    case 3:
                    NiveauExperience = NiveauExperience.professionnel;
                    force = Random.Next(3, 11);
                    dexterite = Random.Next(3, 11);
                    break;
            }

        }
        public override string ToString()
        {
            return $"nom du joueur : {nom} - force : {force} - dextérité : {dexterite} - niveau d'expérience du joueur : {NiveauExperience}";
        }
    }
}
