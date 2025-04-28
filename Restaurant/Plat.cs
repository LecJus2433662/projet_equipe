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
            double prixFinal = 0;
            double taxeUni = 1.5;
            foreach (var ingredient in ing)
            {
                if(ingredient.QualiteIng == Qualite.Excellente)
                    taxeUni += 3;
                else if(ingredient.QualiteIng == Qualite.Moyenne)
                    taxeUni += 2;
                else 
                    taxeUni += 1; 
            }
            prixFinal = CalculerCout() * taxeUni;
            return prixFinal;
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
            return $"Nom du plat : {Nom}, Prix des ingrédients : {PrixIngredient}\n";
        }
    }
}
