using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetFinalJYF.Models
{
    public class Arbitre
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string DDN { get; set; }
        public string Club { get; set; }
        public string Numéro { get; set; }
        public string Voie { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Niveau { get; set; }
        public string Telephone { get; set; }
        public string Courriel { get; set; }
        public string[] listIndispo { get; set; }
    }
}