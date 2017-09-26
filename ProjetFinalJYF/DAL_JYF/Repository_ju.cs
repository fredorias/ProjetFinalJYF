using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_JYF
{
    public partial class Repository
    {

        public IEnumerable<Arbitre> GetAllArbitre()
        {
            return Context.Arbitres.Include("AdresseArb");
        }

        public IEnumerable<Match> GetMatchsSansArb()
        {
            return Context.Matchs.Where(p => p.ArbitreMatch == null).OrderBy(match => match.NiveauMatch).ToList();
        }

        public Arbitre GetAbitreDispoFromMatch(int matchId)
        {
            var requete = from arbitre in Context.Arbitres
                          join dispo in Context.Disponibilites on arbitre.ArbitreId equals dispo.ArbitreDispo.ArbitreId
                          join match in Context.Matchs on dispo.CalendrierDispo.CalendrierId equals match.CalendrierMatch.CalendrierId
                          where dispo.Statut == true && match.MatchId == matchId && dispo.Designe == false
                          orderby arbitre.NiveauArbitre
                          select arbitre;

            return requete.FirstOrDefault();

        }


        public Disponibilite GetDispoFromMatch(int matchId)
        {
            var requete = from dispo in Context.Disponibilites
                          join match in Context.Matchs on new { dispo.CalendrierDispo.CalendrierId, dispo.ArbitreDispo.ArbitreId } equals new { match.CalendrierMatch.CalendrierId, match.ArbitreMatch.ArbitreId }
                          where match.MatchId == matchId
                          select dispo;

            return requete.FirstOrDefault();

        }


        public void UpdateMatchWithArbitre(Match matchToUpdate, Arbitre arbitre)
        {
            matchToUpdate.ArbitreMatch = arbitre;
            Context.SaveChanges();
        }
        public void UpdateDispo(Disponibilite dispo)
        {
            dispo.Designe = true;
            Context.SaveChanges();
        }



    }

}
