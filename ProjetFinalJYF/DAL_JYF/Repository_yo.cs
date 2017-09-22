using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_JYF
{
    public partial class Repository
    {
        public ArbitreContext Context = new ArbitreContext();

        public IEnumerable<Match> GetAllMatch()
        {
            return Context.Matchs.Include("AdresseMatch").Include("ArbitreMatch").Include("CalendrierMatch");
        }

        public IEnumerable<Arbitre> GetArbDispo(DateTime dateDispo)
        {
            var requete = from arbitre in Context.Arbitres
                          join dispo in Context.Disponibilites on arbitre.ArbitreId equals dispo.ArbitreDispo.ArbitreId
                          join calendrier in Context.Calendriers on dispo.CalendrierDispo.CalendrierId equals calendrier.CalendrierId
                          where dispo.Statut == true && calendrier.DateJournee == dateDispo //&& dispo.Designe==false
                          select arbitre;

            return requete;

        }

        public int Add(Match newMatch)
        {

            Context.Matchs.Add(newMatch);
            return Context.SaveChanges();
        }
       public void Update(Match matchToUpdate, Match newMatch)
        {
            matchToUpdate.Visiteurs = newMatch.Visiteurs;
            matchToUpdate.Locaux = newMatch.Locaux;
            matchToUpdate.HeureMatch = newMatch.HeureMatch;
            matchToUpdate.NiveauMatch = newMatch.NiveauMatch;
            matchToUpdate.AdresseMatch = newMatch.AdresseMatch;
            matchToUpdate.CalendrierMatch = newMatch.CalendrierMatch;

            Arbitre arbToUpDate = matchToUpdate.ArbitreMatch;


            Context.SaveChanges();
        }
        
       
    }
}
