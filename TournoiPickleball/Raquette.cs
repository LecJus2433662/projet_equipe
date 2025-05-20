using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournoiPickleball
{


    public abstract class Raquette
    {
        public string Marque { get; protected set; }
        public double Durabilite { get; protected set; }
        public double DurabiliteMax { get; protected set; }

        public Raquette(string marque, int durabiliteMax)
        {
            Marque = marque;
            DurabiliteMax = durabiliteMax;
            Durabilite = durabiliteMax;
        }

        

        public void UserRaquette(int quantite)
        {
            Durabilite -= quantite;
            if (Durabilite < 0)
            {
                Durabilite = 0;
            }
        }
        public override string ToString()
        {
            string etat = "";
            etat = $"Raquette {Marque} - Durabilité : {Durabilite}/{DurabiliteMax}\n";

            double ratio = Durabilite / DurabiliteMax;

            if (ratio >= 0.61)
            {
                etat += "Raquette prête à l’utilisation !";
            }
            else if (ratio >= 0.31)
            {
                etat += "Votre raquette commence à s’user. Pensez à la faire vérifier bientôt.";
            }
            else
            {
                etat += "Raquette en mauvais état. Réparation urgente recommandée !";
            }
            return etat; 
        }
    }
}
