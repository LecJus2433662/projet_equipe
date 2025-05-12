using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Menu
    {
        List<Plat> plats;
        string Nom { get; set; }



        public Menu(string nom)
        {
            plats = new List<Plat>();
            Nom = nom;
        }

        public void AjouterPlat(Plat plat)
        {
            plats.Add(plat);
        }

        public string GetInfoPlat()
        {
            string afficher = "";
            foreach (Plat plat in plats)
            {
                afficher += plat + "\n";
            }
            return afficher;
        }
        public override string ToString()
        {
            return $"Votre menu s'appelle - [{Nom}]\n\n" + GetInfoPlat();
        }
    }
}
