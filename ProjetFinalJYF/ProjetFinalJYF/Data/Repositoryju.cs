using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetFinalJYF.Data
{
    public class Repositoryju
    {
        private ArbitreContext Context = new ArbitreContext();

        internal IEnumerable<Arbitre> GetAllArbitre()
        {
            return Context.Arbitres.Include("AdresseArb");
        }
    }
}