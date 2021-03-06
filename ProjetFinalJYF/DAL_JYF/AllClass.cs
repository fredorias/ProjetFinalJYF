﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_JYF
{

    public class Match
    {
        public int MatchId { get; set; }
        public string Visiteurs { get; set; }
        public string Locaux { get; set; }
        [DisplayName("Heure")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HeureMatch { get; set; }
        [DisplayName("Adresse")]
        public Adresse AdresseMatch { get; set; }
        [DisplayName("Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Calendrier CalendrierMatch { get; set; }
        [DisplayName("Niveau")]
        public string NiveauMatch { get; set; }
        [DisplayName("Arbitre")]
        public Arbitre ArbitreMatch { get; set; }
    }
    public class Arbitre
    {
        public int ArbitreId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

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
        public DateTime DateJournee { get; set; }

    }
    public class Adresse
    {
        public int AdresseId { get; set; }
        [DisplayName ("Nom du Stade")]
        public string NomAdresse { get; set; }
        public string Numero { get; set; }
        public string Complement { get; set; }
        public string Rue { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
    }
    public class Disponibilite
    {
        public int DisponibiliteId { get; set; }
        public Arbitre ArbitreDispo { get; set; }
        public Calendrier CalendrierDispo { get; set; }
        public Boolean Statut { get; set; }
        public Boolean Designe { get; set; }
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

}
