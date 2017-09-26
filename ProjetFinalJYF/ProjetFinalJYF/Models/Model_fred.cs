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
            if (ListIndispo != null)
                foreach (var code in ListIndispo)
                {
                    Disponibilite disp = new Disponibilite()
                    {
                        ArbitreDispo = arb,
                        CalendrierDispo = new Calendrier { DateJournee = Tools.ConvertCodeToDate(code) },
                        Statut = false

                    };
                    repo.AddDisponibilites(disp);
                }





        }

        //Récupérer le informations de l'arbitre à modifier dans la base de donnée 
        public FormArbitre Get(int id)
        {
            //Appel au repository
            Arbitre arbitre = repo.GetArbitre(id);
            Adresse adresse = repo.GetAdresse(arbitre);
            DateTime[] indispos = repo.GetIndispos(arbitre);

            if (arbitre != null)
            {
                //Informations arbitre
                this.Nom = arbitre.Nom;
                this.Prenom = arbitre.Prenom;
                this.Club = arbitre.Club;
                this.DateNaissance = arbitre.DateNaissance;
                this.Niveau = arbitre.NiveauArbitre;
                this.Telephone = arbitre.Telephone;
                this.Courriel = arbitre.Mail;

                //Adresse Arbitre
                this.Numero = adresse.Numero;
                this.Voie = adresse.Rue;
                this.Ville = adresse.Ville;
                this.CodePostal = adresse.CodePostal;



                string[] indispoStr = new string[indispos.Length];
                for (int i = 0; i < indispos.Length; i++)
                {
                    indispoStr[i] = Tools.ConvertDateToCode(indispos[i]);
                }

                this.ListIndispo = indispoStr;
            }
            return this;
        }
    }
}
