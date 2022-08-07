using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto_final.Models;

namespace Projeto_final.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Erro"] != null) {
                ViewBag.erro = Session["Erro"].ToString();
            }
            return View();

        }

        [HttpPost]

        public void CheckLogin()
        {
            var usuário = new User();
            usuário.Usuario = Request["Usuario"];
            usuário.Senha = Request["Senha"];

            if (usuário.Login())
            {
                Session["Autorizado"] = "Ok";
                Session.Remove("Erro");
                Response.Redirect("/Home/Register");
            }
            else
            {
                Session["Erro"] = "Senha ou Usuário invalido";
                Response.Redirect("/Login/Index");
            }
        }
    }
}