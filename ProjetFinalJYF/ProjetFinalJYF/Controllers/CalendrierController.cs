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

        // GET: Calendrier
        public ActionResult Index()
        {
            return View(CalRepo.GetAllMatch());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Affiche le formulaire
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
            if (match == null)
            {
                return RedirectToAction("error");
            }
            if (ModelState.IsValid)
            {
                CalRepo.Update(match, matchDuFormulaire);
                return View(match);

            }
            else
                return View(match);

        }
     


    }
}