using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Client
    {
        int nbClient;
        List<Visiteur> visiteurs;

        public Client(int nbClient)
        {
            this.nbClient = nbClient;
        }


        

        public override string ToString()
        {
            return $"{nbClient}\n{visiteurs}";
        }
    }
}

