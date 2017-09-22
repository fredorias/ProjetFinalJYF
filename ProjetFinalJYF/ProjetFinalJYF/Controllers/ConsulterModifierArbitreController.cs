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


            return Json(arbRepo.GetArbitres(NiveauxRecherches, selectionNiveau.textNom, selectionNiveau.textClub)
                , JsonRequestBehavior.AllowGet);
        }
        //[HttpGet]
        //public ActionResult ModifierArbitre(FormArbitre FormArbitreAModifier)
        //{

        //        return View(); 

        //}
    }
}
