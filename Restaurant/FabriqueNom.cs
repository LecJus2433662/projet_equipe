using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    static class FabriqueNom
    {
        static List<string> ListNom = new List<string>();
        static List<string> ListPrenom = new List<string>();
        static Random Rand = new Random();

        static public void RemplirListe()
        {
            AjouterNom();
            AjouterPrenom();
        }

        static void AjouterNom()
        {
            string fichierNomFamille = @"..\..\..\..\nom_famille.txt";

            using (StreamReader reader = new StreamReader(fichierNomFamille))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ListNom.Add(line);
                }
            }
        }
        static void AjouterPrenom()
        {
            string fichierPrenom = @"..\..\..\..\prenom.txt";
            using (StreamReader reader = new StreamReader(fichierPrenom))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ListPrenom.Add(line);
                }
            }
        }

        static public string GetRandomNom()
        {
            if (ListNom.Count == 0)
                throw new InvalidOperationException("La liste des noms est vide.");
            return ListNom[Rand.Next(ListNom.Count)];
        }

        static public string GetRandomPrenom()
        {
            if (ListPrenom.Count == 0)
                throw new InvalidOperationException("La liste des prénoms est vide.");
            return ListPrenom[Rand.Next(ListPrenom.Count)];
        }
    }
}

