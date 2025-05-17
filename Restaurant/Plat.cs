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
        public List<Ingredient> ingrediantDispo;
        public List<Ingredient> ingredientsPlat;
        string Nom { get; set; }
        double PrixIngredient { get; set; }
        public double PrixAchat { get; set; }

        public Plat(string nom)
        {
            ingrediantDispo = JsonFileLoader.ChargerFichier<List<Ingredient>>(@"..\..\..\..\json_ingredient.json");
            ingredientsPlat = new List<Ingredient>();
            this.Nom = nom;
            PrixAchat = CalculerVente();
        }

        public double CalculerCout()
        {
            double result = 0;

            foreach (Ingredient ingredient in ingredientsPlat)
            {
                result += ingredient.PrixAchat;
            }
            return result;
        }

        public double CalculerVente()
        {
            double prixFinal = 0;
            double taxeUni = 1.5;
            foreach (var ingredient in ingredientsPlat)
            {
                if (ingredient.QualiteIng == Qualite.Excellente)
                    taxeUni += 3;
                else if (ingredient.QualiteIng == Qualite.Moyenne)
                    taxeUni += 2;
                else
                    taxeUni += 1;
            }
            prixFinal = CalculerCout() * taxeUni;
            return prixFinal;
        }

        public string InfoIngrediantDispo()
        {
            string afficher = "";
            int num = 1;
            foreach (Ingredient ingrediant in ingrediantDispo)
            {
                afficher += "\t" + num + ":";
                afficher += ingrediant + "\n";
                num++;
            }
            return afficher;
        }
        public override string ToString()
        {
            return $"Nom du plat : {Nom}, Prix : {PrixAchat:F2}$\n";
        }
    }
}
