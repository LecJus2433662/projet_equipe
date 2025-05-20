using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Menu
    {
        public List<Plat> Plats { get; private set; }
        private string Nom { get; set; }

        public Menu(string nom)
        {
            Plats = new List<Plat>();
            Nom = nom;
        }

        public void AjouterPlat(Plat plat)
        {
            Plats.Add(plat);
        }

        public string GetInfoPlat()
        {
            string afficher = "";
            foreach (Plat plat in Plats)
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
