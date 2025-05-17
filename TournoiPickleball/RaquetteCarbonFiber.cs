using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournoiPickleball
{
    public class RaquetteCarbonFiber : Raquette
    {
         string nom;

        public RaquetteCarbonFiber(int durabilite, int poid) : base(durabilite, poid)
        {
            nom = "Raquette en fibre de Carbone";
            Durabilite = durabilite + Random.Next(1, 9);
            Poid = poid + Random.Next(1, 9);
        }

        public override string ToString()
        {
            return $"{nom} - {base.ToString()}";
        }
    }
}
