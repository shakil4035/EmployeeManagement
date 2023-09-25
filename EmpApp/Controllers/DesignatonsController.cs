using Pims.Core.ViewModel.Setup_Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpApp.Controllers
{
    public class DesignatonsController : Controller
    {
        // GET: Designatons
        public ActionResult New()
        {
            var designation = new DeginationViewModel()
            {
                IsActive = true
            };
            return View(designation);
        }
    }
}