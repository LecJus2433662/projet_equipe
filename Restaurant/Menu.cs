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




        public Menu()
        {
            plats = new List<Plat>(); 
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
            return GetInfoPlat();
        }
    }
}
