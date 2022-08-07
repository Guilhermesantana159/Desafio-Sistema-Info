using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto_final.Models;


namespace Projeto_final.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Adicionar()
        {
            return View();
        }

        public ActionResult Alterar(int id)
        {
            var person = new Person();
            person.GetPerson(id);
            ViewBag.Person = person;
            return View();
        }


        public ActionResult Delete(int id)
        { 
            var person = new Person();
            person.GetPerson(id);
            ViewBag.Person = person;
            return View();
        }

        [HttpPost]
        public void Register()
        {
            var person = new Person();
            person.Id = Convert.ToInt32("0" + Request["Id"]);
            person.Codigo = Request["Codigo"];
            person.Nome = Request["Nome"];
            person.Cpf = Convert.ToInt64(Request["Cpf"]);
            person.Endereço = Request["Endereço"];
            person.Telefone = Convert.ToInt64(Request["Telefone"]);

            
            person.Register();

            Response.Redirect("/Home/Register");

        }
        [HttpPost]
        public void Delete()
        {
            var person = new Person();
            person.Id = Convert.ToInt32("0" + Request["Id"]);
            person.Delete();
            Response.Redirect("/Home/Register");

        }
    }
}
