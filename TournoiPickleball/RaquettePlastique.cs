using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournoiPickleball
{
    public class RaquettePlastique:Raquette
    {
        string nom;

        public RaquettePlastique(int durabilite, int poid) : base(durabilite, poid)
        {
            nom = "Raquette en plastique";
            Durabilite = durabilite + Random.Next(1, 4);
            Poid = poid + Random.Next(1, 5);
        }

        public override string ToString()
        {
            return $"{nom} - {base.ToString()}";
        }
    }
}
