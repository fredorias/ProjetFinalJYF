using ProjetFinalJYF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetFinalJYF.Controllers
{
    public class ArbitreModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //Todo todo = new Todo();
            //var request = controllerContext.HttpContext.Request;

            //todo.Titre = request.Form["Titre"].ToString();
            //todo.Etat = bool.Parse(request.Form.GetValues("Etat")[0]);
            //if (request.Form["TodoId"] != null) todo.TodoId = int.Parse(request.Form["TodoId"]);
            //todo.Description = request.Form["Description"].ToString();
            //todo.Utilisateur = request.Form["Utilisateur"].ToString();
            //todo.DateMisAJour = DateTime.Today;
            //if (request.Form["DateCreation"] != null) todo.DateCreation = DateTime.Parse(request.Form["DateCreation"].ToString());

            //return todo;

            FormArbitre formulaire = new FormArbitre();
            var request = controllerContext.HttpContext.Request;

            formulaire.Nom = request.Form["Nom"].ToString();
            formulaire.Prenom = request.Form["Prenom"].ToString();
            formulaire.Nom = request.Form["Nom"].ToString();
            formulaire.Nom = request.Form["Nom"].ToString();
            formulaire.Nom = request.Form["Nom"].ToString();
            formulaire.Nom = request.Form["Nom"].ToString();
            formulaire.Nom = request.Form["Nom"].ToString();

        }
    }
}