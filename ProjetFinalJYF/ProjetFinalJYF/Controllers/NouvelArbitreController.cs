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
        public ActionResult AjouterArbitre()
        {
            var arbitre = new Arbitre();
            return View(arbitre);
        }
        public ActionResult Envoyer()
        {
            var arbitre = new Arbitre();
            return View(arbitre);
        }


    }


}