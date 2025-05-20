using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Client
    {
        public string Nom { get; set; }

        public Client(string nom)
        {
            Nom = nom;
        }

        public override string ToString()
        {
            return $"Client: {Nom}\n";
        }
    }
}
