using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto_final.Controllers
{
    public class ExitController : Controller
    {
        public ActionResult Exit()
        {
            Session.Abandon();
            Response.Redirect("/Login/Index");
            return null;
        }
    }
}