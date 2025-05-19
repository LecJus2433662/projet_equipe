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
        public int Durabilite { get; protected set; }
        public int DurabiliteMax { get; protected set; }

        public Raquette(string marque, int durabiliteMax)
        {
            Marque = marque;
            DurabiliteMax = durabiliteMax;
            Durabilite = durabiliteMax;
        }

        public virtual void AfficherEtat()
        {
            Console.WriteLine($"Raquette {Marque} - Durabilité : {Durabilite}/{DurabiliteMax}");

            double ratio = Durabilite / DurabiliteMax;

            if (ratio >= 0.61)
            {
                Console.WriteLine("Raquette prête à l’utilisation !");
            }
            else if (ratio >= 0.31)
            {
                Console.WriteLine("Votre raquette commence à s’user. Pensez à la faire vérifier bientôt.");
            }
            else
            {
                Console.WriteLine("Raquette en mauvais état. Réparation urgente recommandée !");
            }
        }

        public void UserRaquette(int quantite)
        {
            Durabilite -= quantite;
            if (Durabilite < 0)
            {
                Durabilite = 0;
            }
        }
    }
}
