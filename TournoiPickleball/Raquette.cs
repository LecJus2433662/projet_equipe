using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournoiPickleball
{
    public class Raquette
    {
        public int Durabilite { get; set; }
        public int Poid { get; set; }
        public Random Random { get; set; }

        protected Raquette(int durabilite, int poid)
        {
                Durabilite = durabilite;
                Poid = poid;
                Random = new Random();
            }

            protected Raquette()
            {
                Random = new Random();
                Durabilite = Random.Next(1, 13); 
                Poid = Random.Next(1, 13);
            }

        public override string ToString()
        {
            return $"Durabilité: {Durabilite}\tPoid: {Poid}";
        }
    }
}
