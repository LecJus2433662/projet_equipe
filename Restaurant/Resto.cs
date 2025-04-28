using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Resto
    {
        int total {  get; set; }
       
        
        
        public Resto()
        {
            total = 10000;
            Client client = new Client();
            Menu menu = new Menu();
            Plat plat = new Plat("",34);
            menu.AjouterPlat(plat);
            
        }


        


    }
}
