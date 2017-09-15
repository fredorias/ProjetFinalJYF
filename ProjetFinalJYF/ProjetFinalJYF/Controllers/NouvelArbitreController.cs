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
        public ActionResult AjouterArbitre()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult AjouterArbitre()
        //{
        //    return View();
        //}


        public ActionResult Envoyer()
        {
            return View();
        }


    }


}