using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_JYF
{

    public partial class Repository
    {
        public Repository()
        {
            Context = new ArbitreContext();
        }
        public void AddAdresse(Adresse adr)
        {
            Context.Adresses.Add(adr);
            Context.SaveChanges();
        }

        public void AddDisponibilites(Disponibilite disp)
        {
            Context.Disponibilites.Add(disp);
            Context.SaveChanges();
        }

        public void AddArbitre(Arbitre arb)
        {
            Context.Arbitres.Add(arb);
            Context.SaveChanges();
        }

        public Arbitre[] GetArbitres(string niveauxRecherches, string textNom, string textClub)
        {
            return Context.Arbitres.Include("AdresseArb").Where(p =>
                                                (niveauxRecherches.Equals("") || niveauxRecherches.Contains(p.NiveauArbitre))
                                                &&
                                                (textNom == null || p.Nom.Contains(textNom.ToUpper()))
                                                &&
                                                (textClub == null || p.Club.ToUpper() == textClub.ToUpper())
                                          ).ToArray();
        }


        //Récupérer les informations d'un arbitre à modifier de la base de données
        public Arbitre GetArbitre(int id)
        {
            return Context.Arbitres.Include("AdresseArb").Where(a => a.ArbitreId == id).FirstOrDefault();
        }

        //Récupérer l'adresse d'un arbitre à modifier de la base de données
        public Adresse GetAdresse(Arbitre arbitreAModifier)
        {

            if (arbitreAModifier == null) return null;
            var requete = from adresse in Context.Adresses
                          join arbitre in Context.Arbitres on adresse.AdresseId equals arbitre.AdresseArb.AdresseId
                          where arbitre.ArbitreId == arbitreAModifier.ArbitreId
                          select adresse;

            return requete.FirstOrDefault();
        }

        //Récupérer les dates d'indispo d'un arbitre à modifier de la base de données
        public DateTime[] GetIndispos(Arbitre arbitreAModifier)
        {
            if (arbitreAModifier == null) return null;
            var requete = from arbitre in Context.Arbitres
                          join dispo in Context.Disponibilites on arbitre.ArbitreId equals dispo.ArbitreDispo.ArbitreId
                          where dispo.Statut == false
                          select dispo.CalendrierDispo.DateJournee;

            return requete.ToArray();

        }
        public void UpdateArbitre()
        {
            Context.SaveChanges();
        }
    }
}
