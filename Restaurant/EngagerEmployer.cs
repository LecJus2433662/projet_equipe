using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public enum RareteEmployer
    {
        Commun,
        Rare,
        TresRare,
        Legendaire
    }
    public class EngagerEmployer
    {
        string Nom { get; set; }
        RareteEmployer RareteEmployer { get; set; }

        public EngagerEmployer(string nomEmployer)
        {
            Nom = nomEmployer;
        }

        public string DeterminerType(RareteEmployer rareter)
        {
            Random rnd = new Random();
            int typeEmployer = 0;
            int nouveauPrix = 0;
            typeEmployer = rnd.Next(1, 5);

            if (typeEmployer == 1)
            {
                rareter = RareteEmployer.Commun;
                nouveauPrix = rnd.Next(1, 11);
            }
            else if (typeEmployer == 2)
            {
                rareter =  RareteEmployer.Rare;
                nouveauPrix = rnd.Next(11, 21);

            }
            else if (typeEmployer == 3)
            {
                rareter = RareteEmployer.TresRare;
                nouveauPrix = rnd.Next(21, 31);

            }
            else if (typeEmployer == 4)
            {
                rareter = RareteEmployer.Legendaire;
                nouveauPrix = rnd.Next(31, 51);

            }
            return $"L'employer mystérieux est de rareter : [{rareter}] et il s'appelle : [{Nom}]\nVous avez droit à une belle réduction de : {nouveauPrix}$";


        }

        public override string ToString()
        {
            return DeterminerType(RareteEmployer);
        }
    }
}
