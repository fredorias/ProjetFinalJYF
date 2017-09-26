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
        public IEnumerable<Arbitre> GetAllArb()
        {
            return Context.Arbitres.Include("AdresseArb");
        }

        public IEnumerable<Arbitre> GetArbDispo(DateTime dateDispo)
        {
            var requete = from arbitre in Context.Arbitres
                          join dispo in Context.Disponibilites on arbitre.ArbitreId equals dispo.ArbitreDispo.ArbitreId
                          join calendrier in Context.Calendriers on dispo.CalendrierDispo.CalendrierId equals calendrier.CalendrierId
                          where dispo.Statut == true && calendrier.DateJournee == dateDispo && dispo.Designe == false
                          orderby arbitre.NiveauArbitre, arbitre.Nom ascending
                          select arbitre;

            return requete;

        }
        public IEnumerable<Match> GetMatchPeriode(DateTime DateDebut, DateTime DateFin)
        {
            var requete = from match in Context.Matchs.Include("AdresseMatch").Include("ArbitreMatch").Include("CalendrierMatch")
                          join cal in Context.Calendriers on match.CalendrierMatch.CalendrierId equals cal.CalendrierId
                          where cal.DateJournee >= DateDebut && cal.DateJournee <= DateFin
                          orderby match.CalendrierMatch.DateJournee ascending
                          select match;
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
            matchToUpdate.AdresseMatch.NomAdresse = newMatch.AdresseMatch.NomAdresse;
            matchToUpdate.AdresseMatch.Numero = newMatch.AdresseMatch.Numero;
            matchToUpdate.AdresseMatch.Rue = newMatch.AdresseMatch.Rue;
            matchToUpdate.AdresseMatch.Ville = newMatch.AdresseMatch.Ville;
            matchToUpdate.AdresseMatch.CodePostal = newMatch.AdresseMatch.CodePostal;

            matchToUpdate.CalendrierMatch= newMatch.CalendrierMatch;

            matchToUpdate.ArbitreMatch = newMatch.ArbitreMatch;
            Context.SaveChanges();
        }
        //public void DesigneTrue (Match m)
        //{
        //    var calId = m.CalendrierMatch.CalendrierId;
        //    var arbId = m.ArbitreMatch.ArbitreId;

        //    var dispo = Context.Disponibilites.Where(d => d.CalendrierDispo.CalendrierId == calId && d.ArbitreDispo.ArbitreId == arbId).FirstOrDefault();
        //    dispo.Designe = true;
        //    Context.SaveChanges();
        //}
        //public void DesigneFalse (Arbitre ex, Match m)
        //{
        //     var calId = m.CalendrierMatch.CalendrierId;
        //    var arbId = ex.ArbitreId;
        //    var dispo = Context.Disponibilites.Where(d => d.CalendrierDispo.CalendrierId == calId && d.ArbitreDispo.ArbitreId == arbId).FirstOrDefault();
        //    dispo.Designe = false;
        //    Context.SaveChanges();
        //}
        public void ChangeDesigne(Match m)
        {
            if (m.ArbitreMatch != null)
            {
                var calId = m.CalendrierMatch.CalendrierId;
                var arbId = m.ArbitreMatch.ArbitreId;
                var dispo = Context.Disponibilites.Where(d => d.CalendrierDispo.CalendrierId == calId && d.ArbitreDispo.ArbitreId == arbId).FirstOrDefault();
                if (dispo != null)
                {
                    if (dispo.Designe == true)
                    {
                        dispo.Designe = false;
                    }
                    else
                    {
                        dispo.Designe = true;
                    }
                }



                Context.SaveChanges();
            }


        }
        public Calendrier GetCalByDate(DateTime date)
        {
            var requete = Context.Calendriers.Where(c => c.DateJournee == date).FirstOrDefault();
            return requete;
        }
    }
}
