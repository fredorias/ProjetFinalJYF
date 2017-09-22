using DAL_JYF;
using ProjetFinalJYF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetFinalJYF.Controllers
{
    public class ConsulterModifierArbitreController : Controller
    {
        Repository arbRepo = new Repository();
        private List<string> ListeNiveau = null;
        private List<Arbitre> ListeArbitre = null;


        public ActionResult ConsulterModifier()
        {

            return View();

        }

        //public ConsulterModifierArbitreController()
        //{
        //    ListeNiveau = new List<string>
        //            {

        //            "Tous les niveaux",
        //            "Federal",
        //                "Stagiaire",
        //               "ACF",
        //               "Territorial",
        //               "PreFederal"
        //            };

        //    ListeArbitre = new List<Arbitre>
        //{
        //    new Arbitre {Nom="ORIAS",Prenom="Fred", NiveauArbitre= ListeNiveau[1],Club="Le Lou",Telephone="0698563214",AdresseVille="Vernaison",DateNaissance= new DateTime(1987,09,16)},
        //    new Arbitre {Nom="DESPINASSE",Prenom="Yo", NiveauArbitre= ListeNiveau[1],Club="ST",Telephone="0632547854",AdresseVille="Toulouse",DateNaissance= new DateTime(1986,09,15)},
        //    new Arbitre {Nom="GORNET",Prenom="Ju", NiveauArbitre= ListeNiveau[2],Club="UBB",Telephone="0654785412",AdresseVille="Bordeaux",DateNaissance= new DateTime(1997,12,16)},
        //    new Arbitre {Nom="ARNAUD",Prenom="Jo",NiveauArbitre= ListeNiveau[3],Club="UBB",Telephone="0654785412",AdresseVille="Bordeaux",DateNaissance= new DateTime(1997,12,16)},
        //    new Arbitre {Nom="CHERBAL",Prenom="Amin", NiveauArbitre= ListeNiveau[2],Club="Le Lou",Telephone="0321456398",AdresseVille="Lyon",DateNaissance= new DateTime(1942,02,18)},
        //    new Arbitre {Nom="MAKRI",Prenom="Ali", NiveauArbitre= ListeNiveau[4],Club="Clermont",Telephone="0547896523",AdresseVille="Clermont",DateNaissance= new DateTime(1987,02,12)},
        //};

        //}
        [HttpGet]
        public ActionResult Afficher(NiveauxFiltre selectionNiveau)
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

            ListeArbitre = new List<Arbitre>();
            //ListeArbitre = arbRepo.GetAllArbitre().ToList();
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

            return Json(ListeArbitre.Where(p =>
                                                (NiveauxRecherches.Equals("") || NiveauxRecherches.Contains(p.NiveauArbitre))
                                                &&
                                                (selectionNiveau.textNom == null || p.Nom.Contains(selectionNiveau.textNom.ToUpper()))
                                                &&
                                                (selectionNiveau.textClub == null || p.Club.ToUpper() == selectionNiveau.textClub.ToUpper())
                                          )
            .ToArray(), JsonRequestBehavior.AllowGet);
        }

    }
}
