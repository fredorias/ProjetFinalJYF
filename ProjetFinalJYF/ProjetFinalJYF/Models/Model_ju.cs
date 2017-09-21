using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetFinalJYF.Models
{
 
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