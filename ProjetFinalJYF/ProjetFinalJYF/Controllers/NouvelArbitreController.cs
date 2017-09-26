using ProjetFinalJYF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetFinalJYF.Controllers
{
    public class NouvelArbitreController : Controller
    {
        // GET: NouvelArbitre

        [HttpGet]
        public ActionResult EditerArbitre(int id=0)
        {
            FormArbitre formulaire = new FormArbitre();
            ViewBag.formulaire = formulaire.Get(id);
            ViewBag.ArbitreId = id;
            return View(formulaire);
        }

        [HttpPost]
        public ActionResult EditerArbitre(FormArbitre formulaire)
        {
            formulaire.Save();
            return Json("Vos données ont bien été enregistrées !"); // redirection to action ?
        }


    


    }

}