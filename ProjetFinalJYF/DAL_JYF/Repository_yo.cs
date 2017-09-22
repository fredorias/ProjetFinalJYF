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

        public IEnumerable<Arbitre> GetArbDispo(DateTime dateDispo, bool statut = true)
        {
            var requete = from arbitre in Context.Arbitres
                          join dispo in Context.Disponibilites on arbitre.ArbitreId equals dispo.ArbitreDispo.ArbitreId
                          join calendrier in Context.Calendriers on dispo.CalendrierDispo.CalendrierId equals calendrier.CalendrierId
                          where dispo.Statut == statut && calendrier.DateJournee == dateDispo
                          select arbitre;

            return requete;

        }

        public int Add(Match newMatch)
        {

            Context.Matchs.Add(newMatch);
            return Context.SaveChanges();
        }
       public void Update(Match matchToUpdate, Match newData)
        {
            matchToUpdate.Visiteurs = newData.Visiteurs;
            matchToUpdate.Locaux = newData.Locaux;
            matchToUpdate.HeureMatch = newData.HeureMatch;
            matchToUpdate.NiveauMatch = newData.NiveauMatch;
            matchToUpdate.AdresseMatch = newData.AdresseMatch;
            matchToUpdate.ArbitreMatch = newData.ArbitreMatch;
            matchToUpdate.CalendrierMatch = newData.CalendrierMatch;

            Context.SaveChanges();
        }

       
    }
}
