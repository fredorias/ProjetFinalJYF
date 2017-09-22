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
    }
}
