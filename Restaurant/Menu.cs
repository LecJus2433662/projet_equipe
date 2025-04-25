using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Menu
    {
        List<Menu> menu { get; set; }
        string nom { get; set; }
        int note { get; set; }

        public Menu(string nom, int note)
        {
            menu = new List<Menu>();
            this.nom = nom;
            this.note = note;
        }

        public void AjouterMenu(Menu plat)
        {
            menu.Add(plat);
        }

        private string AfficherMenu()
        {
            string afficher = "";
            foreach (Menu filmAfficher in menu)
            {
                afficher += filmAfficher + "\n";
            }
            return afficher;
        }
        public override string ToString()
        {
            return $"Nom du menu : {nom}, la note general du menu est {note}/5";
        }
    }
}
