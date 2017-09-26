using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebScraper.WCF;

namespace DAL_JYF
{
    class ServiceWCFClient
    {
        public static void TestArbitreService()
        {
            //Console.WriteLine("TestArbitreService");
            // Client WCF
            ChannelFactory<IArbitreService> Canal2 = new ChannelFactory<IArbitreService>("CanalArbitre");
            IArbitreService serv2 = Canal2.CreateChannel();

            var r = serv2.GetAllMatchsByQueryName("Arbitres");

            //Console.ReadLine();


        }
    }
}
