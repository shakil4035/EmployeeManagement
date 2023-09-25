using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpApp.Controllers
{
    public class LanguagesController : Controller
    {
        // GET: Languages
        public ActionResult Language()
        {
            return View();
        }
    }
}