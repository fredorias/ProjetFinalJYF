using DAL_JYF;
using ProjetFinalJYF.Binder;
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

        // GET: Calendrier
        public ActionResult Index()
        {
            return View(CalRepo.GetAllMatch());
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
            var match = CalRepo.GetAllMatch().Where(t => t.MatchId == matchDuFormulaire.MatchId).FirstOrDefault();
            var newArb = CalRepo.GetAllArb().Where(a => a.ArbitreId == matchDuFormulaire.ArbitreMatch.ArbitreId).FirstOrDefault();
            matchDuFormulaire.AdresseMatch.AdresseId = match.AdresseMatch.AdresseId;
            matchDuFormulaire.CalendrierMatch.CalendrierId = match.CalendrierMatch.CalendrierId;
            var oldArb = match.ArbitreMatch;
            if (match == null)
            {
                return RedirectToAction("error");
            }
            if (ModelState.IsValid)
            {
                matchDuFormulaire.ArbitreMatch = newArb;
                CalRepo.ChangeDesigne(matchDuFormulaire); //changement désignation de false a true
                CalRepo.ChangeDesigne( match); //changement désignation de false a true
                CalRepo.Update(match, matchDuFormulaire);
                var arbdispo = CalRepo.GetArbDispo(match.CalendrierMatch.DateJournee); //remet la liste des arb disp a jour
                ViewBag.ListeArbitresDispo = arbdispo;
                return View(match);
            }
            else
                return View(match);
            
        }
     


    }
}