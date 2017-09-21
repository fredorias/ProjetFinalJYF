using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetFinalJYF.Controllers
{
    public class ConsulterModifierArbitreController : Controller
    {
        private List<string> ListeNiveau = null;
        private List<Arbitre> ListeArbitre = null;


        public ActionResult ConsulterModifier()
        {

            return View();

        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ConsulterModifierArbitreController()
        {
            ListeNiveau = new List<string>
                    {

                    "Tous les niveaux",
                    "Federal",
                        "Stagiaire",
                       "ACF",
                       "Territorial",
                       "PreFederal"
                    };

            ListeArbitre = new List<Arbitre>
        {
            new Arbitre {Nom="Orias",Prenom="Fred", NiveauArbitre= ListeNiveau[1],Club="Le Lou",Téléphone="0698563214",Adresse="Vernaison",DDN= new DateTime(1987,09,16)},
            new Arbitre {Nom="Despinasse",Prenom="Yo", NiveauArbitre= ListeNiveau[1],Club="ST",Téléphone="0632547854",Adresse="Toulouse",DDN= new DateTime(1986,09,15)},
            new Arbitre {Nom="Gornet",Prenom="Ju", NiveauArbitre= ListeNiveau[2],Club="UBB",Téléphone="0654785412",Adresse="Bordeaux",DDN= new DateTime(1997,12,16)},
            new Arbitre {Nom="Arnaud",Prenom="Jo",NiveauArbitre= ListeNiveau[3],Club="UBB",Téléphone="0654785412",Adresse="Bordeaux",DDN= new DateTime(1997,12,16)},
            new Arbitre {Nom="Cherbal",Prenom="Amin", NiveauArbitre= ListeNiveau[2],Club="Le Lou",Téléphone="0321456398",Adresse="Lyon",DDN= new DateTime(1942,02,18)},
            new Arbitre {Nom="Makri",Prenom="Ali", NiveauArbitre= ListeNiveau[4],Club="Clermont",Téléphone="0547896523",Adresse="Clermont",DDN= new DateTime(1987,02,12)},
        };

        }
        [HttpGet]
        public ActionResult Afficher(NiveauxFiltre selectionNiveau)
        {
            //return Json(ListeArbitre.ToArray(), JsonRequestBehavior.AllowGet);
            string NiveauxRecherches = "";
            if (selectionNiveau.federal)
            {
                NiveauxRecherches += ListeNiveau[1];
            }
            if (selectionNiveau.stagiaire)
            {
                NiveauxRecherches += ListeNiveau[2];
            }
            if (selectionNiveau.ACF)
            {
                NiveauxRecherches += ListeNiveau[3];
            }
            if (selectionNiveau.territorial)
            {
                NiveauxRecherches += ListeNiveau[4];
            }
            if (selectionNiveau.preFederal)
            {
                NiveauxRecherches += ListeNiveau[5];
            }
            if (selectionNiveau.touslesniveaux)
            {
                NiveauxRecherches = "";
            }


            return Json(ListeArbitre.Where(p => NiveauxRecherches.Equals("") || NiveauxRecherches
            .Contains(p.NiveauArbitre))

            .ToArray(), JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Afficher()
        //{
        //    //if Json((document.getElementById('cb_Federal').checked == true))
        //    //{ 

        //    //return Json(ListeArbitre.Where(p => p.NiveauArbitre == ListeNiveau[2]).ToArray(), JsonRequestBehavior.AllowGet);
        //    //    }
        //    //    else {
        //    return Json(ListeArbitre[1], JsonRequestBehavior.AllowGet);
        //        }




        //    [HttpGet]

        //    public ActionResult Afficher()
        //    {
        //        return Json(ListeArbitre.Where(p => p.NiveauArbitre == ListeNiveau[1]).ToArray(), JsonRequestBehavior.AllowGet);

        //}
        //public Arbitre[] Post([FromBody]string niveau)
        //{
        //    return ListeArbitre.Where(p => p.NiveauArbitre == niveau).ToArray();

        //}


        public class NiveauxFiltre
        {
            public bool federal { get; set; }
            public bool touslesniveaux { get; set; }
            public bool ACF { get; set; }
            public bool territorial { get; set; }
            public bool stagiaire { get; set; }
            public bool preFederal { get; set; }
        }
        public class Arbitre
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string NiveauArbitre { get; set; }
            public string Club { get; set; }
            public string Téléphone { get; set; }
            public string Adresse { get; set; }
            public DateTime DDN { get; set; }
        }
        public class Federal
        {
            public bool federal { get; set; }
        }




    }
}
