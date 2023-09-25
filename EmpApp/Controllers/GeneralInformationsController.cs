using Pims.Core.Model;
using Pims.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpApp.Controllers
{
    public class GeneralInformationsController : Controller
    {
        // GET: GeneralInformations
        public ActionResult EmployeeCreate(int? id)
        {
            ViewBag.DepartmentId = new SelectList(new List<Department>(), "Id", "Name");
            ViewBag.DesignationId = new SelectList(new List<Designation>(), "Id", "Name");
            return View();
        }
    }
}