using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public partial class Ingredient
    {
        public string Nom { get; set; }
        public double PrixAchat { get; set; }

        public Ingredient(string nom, double achatP)
        {
            this.Nom = nom;
            this.PrixAchat = achatP;
        }

        public override string ToString()
        {
            return $"[Nom] : {Nom}, [prix] : {PrixAchat}$";
        }
    }
}
