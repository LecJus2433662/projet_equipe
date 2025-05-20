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
        public string Nom { get; private set; }
        private float PrixIngredient { get; set; }
        public float PrixAchat { get; set; }

        public Plat(string nom)
        {
            ingrediantDispo = JsonFileLoader.ChargerFichier<List<Ingredient>>(@"..\..\..\..\json_ingredient.json");
            ingredientsPlat = new List<Ingredient>();
            Nom = nom;
            PrixAchat = CalculerVente();
        }

        public float CalculerCout()
        {
            float result = 0;
            foreach (Ingredient ingredient in ingredientsPlat)
            {
                result += ingredient.PrixAchat;
            }
            return result;
        }

        public float CalculerVente()
        {
            float prixFinal = 0;
            float taxeUni = 1;

            foreach (Ingredient ingredient in ingredientsPlat)
            {
                if (ingredient.QualiteIng == Qualite.Excellente) taxeUni += 3;
                else if (ingredient.QualiteIng == Qualite.Moyenne) taxeUni += 2;
                else taxeUni += 1;
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
                afficher += "\t" + num + ":" + ingrediant + "\n";
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
