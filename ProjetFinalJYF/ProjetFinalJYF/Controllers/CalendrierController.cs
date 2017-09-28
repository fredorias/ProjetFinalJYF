using ConsoleApplication1;
using DAL_JYF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetFinalJYF.Controllers
{
    public class CalendrierController : Controller
    {
        public Repository CalRepo = new Repository();
        public List<string> list = new List<string>();
        public SourceMatchWeb SM = new SourceMatchWeb();
        // GET: Calendrier
        public ActionResult Index()
        {
            return View(CalRepo.GetAllMatch());
        }
        public string SourceMatch()
        {
            SM.SourceMatch();
            return "Base de donnée mise à jour";
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Affiche le formulaire et la liste d'arb dispo a cette date grâce au ViewBag
            var match = CalRepo.GetAllMatch().Where(t => t.MatchId == id).FirstOrDefault();
            var arbdispo = CalRepo.GetArbDispo(match.CalendrierMatch.DateJournee);
            ViewBag.ListeArbitresDispo = arbdispo;

            if (match == null)
            {
                return RedirectToAction("index");
            }
            else
                return View(match);

        }
        [HttpPost]
        public ActionResult Edit(Match matchDuFormulaire)
        {
            //Faire les liens entre les id de calendrier et adresse pour ne pas en créer des différentes à chaque fois
            var match = CalRepo.GetAllMatch().Where(t => t.MatchId == matchDuFormulaire.MatchId).FirstOrDefault();
            var newArb = CalRepo.GetAllArb().Where(a => a.ArbitreId == matchDuFormulaire.ArbitreMatch.ArbitreId).FirstOrDefault();
            var cal = CalRepo.GetCalByDate(matchDuFormulaire.CalendrierMatch.DateJournee);

            matchDuFormulaire.AdresseMatch.AdresseId = match.AdresseMatch.AdresseId;
        
            if (matchDuFormulaire.CalendrierMatch.DateJournee == match.CalendrierMatch.DateJournee)
            {
                matchDuFormulaire.CalendrierMatch= match.CalendrierMatch;
            }
            else
            {
                if (cal!=null)
                {
                    matchDuFormulaire.CalendrierMatch= cal;
                }
                else
                {
                    matchDuFormulaire.CalendrierMatch.CalendrierId = matchDuFormulaire.CalendrierMatch.CalendrierId;
                }
            }
            var oldArb = match.ArbitreMatch;
            if (match == null)
            {
                return RedirectToAction("error");
            }
            if (ModelState.IsValid)
            {
                matchDuFormulaire.ArbitreMatch = newArb;
                CalRepo.ChangeDesigne(matchDuFormulaire); //changement désignation de false a true
                CalRepo.ChangeDesigne(match); //changement désignation de false a true
                CalRepo.Update(match, matchDuFormulaire);
                var arbdispo = CalRepo.GetArbDispo(match.CalendrierMatch.DateJournee); //remet la liste des arb disp à jour
                ViewBag.ListeArbitresDispo = arbdispo;
                return View(match);
            }
            else
                return View(match);

        }



    }
}