using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restaurant
{
    public enum Qualite
    {
        Moyenne,
        Bonne,
        Excellente
    }

    public class Ingredient
    {
        public string Nom { get; set; }
        public float PrixAchat { get; set; }
        public int Calorie { get; set; }
        public Qualite QualiteIng { get; set; }

        [JsonConstructor]
        public Ingredient(string nom, float prix, int calories, string qualite)
        {
            Nom = nom;
            PrixAchat = prix;
            Calorie = calories;

            if (qualite.Contains("Moyenne")) QualiteIng = Qualite.Moyenne;
            else if (qualite.Contains("Bonne")) QualiteIng = Qualite.Bonne;
            else if (qualite.Contains("Excellente")) QualiteIng = Qualite.Excellente;
            else QualiteIng = Qualite.Moyenne;
        }

        public override string ToString()
        {
            return $"[Nom] : {Nom}, [prix] : {PrixAchat}$, [Calorie] : {Calorie}, [Qualite] : {QualiteIng}";
        }
    }
}
