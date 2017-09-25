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

        [HttpPost]
        public ActionResult ModifierArbitre(FormArbitre formarbitreAModifier)
        {

            return View();

        }
        [HttpGet]
        public ActionResult AffectationArbitre()
        {
            var macthSansArb = arbRepo.GetMatchsSansArb(); //Méthode du Repository qui récupére les matchs sans arbitres affectés


            foreach (Match match in macthSansArb)
            {
                Arbitre arbitre = arbRepo.GetAbitreDispoFromMatch(match.MatchId);//récupére  les arbitre dispo pour un match sans arbitre
                if (arbitre != null) //condition qui permet que ça laisse les matchs sans arbitres si il n'y en a pas assez.
                {

                    arbRepo.UpdateMatchWithArbitre(match, arbitre); //affecte un arbitre à un match

                    Disponibilite dispo = arbRepo.GetDispoFromMatch(match.MatchId);//change la dispo de l'arbitre affecté au match
                    arbRepo.UpdateDispo(dispo);

                }
            }

            return Json(macthSansArb, JsonRequestBehavior.AllowGet);
        }


    }
}
