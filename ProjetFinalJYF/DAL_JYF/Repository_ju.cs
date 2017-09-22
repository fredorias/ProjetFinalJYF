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
    }
}
