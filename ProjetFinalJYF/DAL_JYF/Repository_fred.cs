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

        

       

        


    }
}
