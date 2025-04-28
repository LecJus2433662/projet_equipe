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
        List<Plat> platt { get; set; }
        string Nom { get; set; }
        double PrixIngredient { get; set; }
        public double PrixAchat { get; private set; }

        public Plat(string nom, double prixIng)
        {
            platt = new List<Plat>();
            this.Nom = nom;
            this.PrixIngredient = prixIng;
        }

        public double CalculerCout()
        {
            double result = 0;

            foreach (Plat p in platt)
            {
                result += p.PrixAchat;
            }
            return result;
        }

        public double CalculerVente()
        { 
            return CalculerCout() * 1.5; 
        }


        public void AjouterPLat(Plat plat)
        {
            platt.Add(plat);
        }

        private string AjouterPlat()
        {
            string afficher = "";
            foreach (Plat filmAfficher in platt)
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
