using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetFinalJYF.Data
{
    public class Match
    {
        public int MatchId { get; set; }
        public string Visiteurs { get; set; }
        public string Locaux { get; set; }
        [DisplayName("Heure")]
        public DateTime HeureMatch { get; set; }
        [DisplayName("Adresse")]
        public Adresse AdresseMatch { get; set; }
        [DisplayName("Date")]
        public Calendrier CalendrierMatch { get; set; }
        [DisplayName("Niveau")]
        public string NiveauMatch { get; set; }
        [DisplayName("Arbitre")]
        public Arbitre ArbitreMatch { get; set; }
    }
    public class FormArbitre
    {
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
                ArbitreId = Guid.NewGuid(),
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
                AdresseId = Guid.NewGuid(),
                CodePostal = CodePostal,
                Numero = Numero,
                Rue = Voie,
                Ville = Ville,
            };

            //foreach élément du tableau de string récupéré, appeler la méthode convertToDate
            foreach (var code in ListIndispo)
            {
                Disponibilite disp = new Disponibilite()
                {
                    DisponibiliteId = new Guid(),
                    ArbitreDispo = arb,
                    CalendrierDispo = new Calendrier { DateJournee = ConvertCodeToDate(code) },
                    Statut = false

                };
            }
            //Context.Arbitres.Add(arb);
            //Context.Addresse.Add(adr);
            //Context.Disponibilite.Add(adr);
            //Context.SaveChanges();
        }

    }
    public class Arbitre
    {
        public Guid ArbitreId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public Adresse AdresseArb { get; set; }
        public string Club { get; set; }
        public string NiveauArbitre { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public Boolean Doublement { get; set; }

    }
    public class Calendrier
    {
        public int CalendrierId { get; set; }
        public DateTime? DateJournee { get; set; }

    }
    public class Adresse
    {
        public Guid AdresseId { get; set; }
        public string NomAdresse { get; set; }
        public string Numero { get; set; }
        public string Complement { get; set; }
        public string Rue { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
    }
    public class Disponibilite
    {
        public Guid DisponibiliteId { get; set; }
        public Arbitre ArbitreDispo { get; set; }
        public Calendrier CalendrierDispo { get; set; }
        public Boolean Statut { get; set; }
    }
    public class ArbitreContext : DbContext
    {
        public ArbitreContext() : base("Name=ArbitreConnectionString") { }

        public DbSet<Match> Matchs { get; set; }
        public DbSet<Arbitre> Arbitres { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Calendrier> Calendriers { get; set; }
        public DbSet<Disponibilite> Disponibilites { get; set; }
    }
    public class NiveauxFiltre
    {
        public bool federal { get; set; }
        public bool touslesniveaux { get; set; }
        public bool ACF { get; set; }
        public bool territorial { get; set; }
        public bool stagiaire { get; set; }
        public bool preFederal { get; set; }

        public string textNom { get; set; }
        public string textClub { get; set; }

    }
}


