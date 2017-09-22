using DAL_JYF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetFinalJYF.Models
{
    
    public class FormArbitre
    {
        Repository repo = new Repository();

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Club { get; set; }
        public string Niveau { get; set; }
        public string Numero { get; set; }
        public string Voie { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        public string Courriel { get; set; }
        public string[] ListIndispo { get; set; }


        public DateTime ConvertCodeToDate(string code)
        {
            // Convertit le code en tableau de 4 string avec '_' comme séparateur
            var tab = code.Split('_');

            //Convertit [0] en mois et [3] en année 
            DateTime jour = new DateTime(
                DateTime.Now.Year + int.Parse(tab[3]),
                int.Parse(tab[0]),
                1);

            //[1] Samedi ou Dimanche
            DayOfWeek jourDeLaSemaine = DayOfWeek.Sunday;
            if (tab[1] == "S") jourDeLaSemaine = DayOfWeek.Saturday;

            //[2] N ième samedi ou dimanche du mois
            var max = int.Parse(tab[2]);
            var n = 0;
            var trouve = false;
            while (!trouve)
            {
                if (jour.DayOfWeek == jourDeLaSemaine)
                {
                    n++;
                    if (n == max)
                    {
                        trouve = true;
                    }
                }
                if (!trouve) jour = jour.AddDays(1);
            }

            return jour;
        }


        //Sauvegarder le formulaire
        public void Save()
        {
            Arbitre arb = new Arbitre()
            {
                Nom = Nom?.ToUpper(),
                Prenom = Prenom?.ToUpper(),
                Club = Club?.ToUpper(),
                DateNaissance = DateNaissance,
                Mail = Courriel,
                Telephone = Telephone,
                NiveauArbitre = Niveau.ToUpper(),
                Doublement = false,
            };
            Adresse adr = new Adresse()
            {
                CodePostal = CodePostal,
                Numero = Numero,
                Rue = Voie,
                Ville = Ville,
            };

            repo.AddArbitre(arb);
            repo.AddAdresse(adr);

            //foreach élément du tableau de string récupéré, appeler la méthode convertToDate
            foreach (var code in ListIndispo)
            {
                Disponibilite disp = new Disponibilite()
                {
                    ArbitreDispo = arb,
                    CalendrierDispo = new Calendrier { DateJournee = ConvertCodeToDate(code) },
                    Statut = false

                };
                repo.AddDisponibilites(disp);
            }


            


        }

    }
}
