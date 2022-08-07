using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto_final.Models;
using System.Collections.ObjectModel;


namespace Projeto_final.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Register()
        {
            if (Session["Autorizado"] != null)
            {
                var lista = Person.GetPerson();
                ViewBag.Lista = lista;
                return View();
            }
            else
            {
                Response.Redirect("/Login/Index");
                return null;
            }
        }
    }
}