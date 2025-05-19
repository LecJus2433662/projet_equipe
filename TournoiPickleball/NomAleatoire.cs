using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournoiPickleball
{
    public static class NomAleatoire
    {
        static List<string> prenoms = new List<string>
        {
            "Mantisse", "Alexis", "Justin", "Tommy", "Alex", "Leo", "Robin", "Vincent", "Francis", "Jimmy"
        };

        static List<string> nomsFamille = new List<string>
        {
            "Labrador", "Turcake", "Léclaire", "Florent", "Alrightttt", "Dent", "Desbois", "Propro", "Guez", "Benoit"
        };

        static Random rand = new Random();




        public static string GetNomComplet()
        {
            string prenom = prenoms[rand.Next(prenoms.Count)];
            string nom = nomsFamille[rand.Next(nomsFamille.Count)];
            return prenom + " " + nom;
        }
        

        
    }
    
}
