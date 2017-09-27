using DAL_JYF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebScraper.WCF;

namespace ConsoleApplication1
{
    public class SourceMatchWeb
    {
       private Repository rep = null;
        
        public void SourceMatch()
        {
            rep = new Repository();
            
            ChannelFactory<IArbitreService> Canal2 = new ChannelFactory<IArbitreService>("CanalArbitre");
            IArbitreService serv2 = Canal2.CreateChannel();

            var resultsServer = serv2.GetAllMatchsByQueryName("Arbitres");

            resultsServer.Select(r => r.NiveauMatch).ToList();

            List<DAL_JYF.Match> newArbL = resultsServer.Select(r => 
                new DAL_JYF.Match() {
                    Locaux=r.Locaux,
                    Visiteurs=r.Visiteurs,
                    HeureMatch=r.HeureMatch,
                    CalendrierMatch= r.CalendrierMatch == null ? null : new DAL_JYF.Calendrier() { DateJournee=r.CalendrierMatch.DateJournee },
                    AdresseMatch= r.AdresseMatch == null ? null : new DAL_JYF.Adresse() { NomAdresse=r.AdresseMatch.NomAdresse },
                    NiveauMatch= Convertir(r.NiveauMatch),
                }

                ).ToList();
            
        rep.AddRange(newArbL);
            
        }

        private static string Convertir(string value)
        {
            if (value == null)
                return "";
            if (value.Equals("Balandrade - Championnat Territorial"))
                return "Série1";
            if (value.Equals("Compétition Libre"))
                return "Promotion d'honneur";
            if (value.Equals("Teuliere - Championnat Territorial"))
                return "Série2";
            if (value.Equals("Réserves Honneur - Championnat Territorial"))
                return "Série3";
            if (value.Equals("Fédérale 1 Féminine"))
                return "Honneur";
            if (value.Equals("Phliponeau B - Championnat Territorial"))
                return "Série4";

            return value;
        }
    }
}
