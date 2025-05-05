using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Client
    {
        
        List<Visiteur> visiteurs;
        

        public Client()
        {
       
        }
        public void AjouterVisiteur(Visiteur visiteur)
        {
            visiteurs.Add(visiteur);
        }

        public int AfficherNombreDeClient()
        {
            int nbClient = 0;
            foreach (Visiteur visiteur in visiteurs)
            {
                nbClient++;
            }
            return nbClient;
        }

        public override string ToString()
        {
            return $"\n{visiteurs}";
        }
    }
}
