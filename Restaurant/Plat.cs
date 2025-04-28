using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Plat
    {
        List<Ingredient> ing { get; set; }
        string Nom { get; set; }
        double PrixIngredient { get; set; }
        public double PrixAchat { get; private set; }

        public Plat(string nom, double prixIng)
        {
            ing = new List<Ingredient>();
            this.Nom = nom;
            this.PrixIngredient = prixIng;
        }

        public double CalculerCout()
        {
            double result = 0;

            foreach (Ingredient ingredient in ing)
            {
                result += ingredient.PrixAchat;
            }
            return result;
        }

        public double CalculerVente()
        { 
            return CalculerCout() * 1.5; 
        }

        private string InfoPlat()
        {
            string afficher = "";
            foreach (Ingredient filmAfficher in ing)
            {
                afficher += filmAfficher + "\n";
            }
            return afficher;
        }
        public override string ToString()
        {
            return $"Nom du plat : {Nom}, Prix des ingrédients : {PrixIngredient}";
        }
    }
}
