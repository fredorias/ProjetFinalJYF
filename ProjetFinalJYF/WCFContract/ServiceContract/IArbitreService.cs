using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WebScraper.WCF
{
    [ServiceContract]
    public interface IArbitreService
    {
        [OperationContract]
        List<Match> GetAllMatchsByQueryName(string queryName);
    }
    [DataContract]
    public class Match
    {
        [DataMember]
        public int MatchId { get; set; }
        [DataMember]
        public string Visiteurs { get; set; }
        [DataMember]
        public string Locaux { get; set; }

        [DataMember]
        public DateTime HeureMatch { get; set; }

        [DataMember]
        public Adresse AdresseMatch { get; set; }

        [DataMember]
        public Calendrier CalendrierMatch { get; set; }

        [DataMember]
        public string NiveauMatch { get; set; }

        //        [DataMember] public Arbitre ArbitreMatch { get; set; }
    }
    [DataContract]
    public class Calendrier
    {
        [DataMember]
        public int CalendrierId { get; set; }
        [DataMember]
        public DateTime DateJournee { get; set; }

    }
    [DataContract]
    public class Adresse
    {
        [DataMember]
        public int AdresseId { get; set; }
        [DataMember]
        public string NomAdresse { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string Complement { get; set; }
        [DataMember]
        public string Rue { get; set; }
        [DataMember]
        public string CodePostal { get; set; }
        [DataMember]
        public string Ville { get; set; }
    }
}