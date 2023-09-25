using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pims.Core.ViewModel;

namespace EmpApp.Controllers
{
    public class DepartmentsController : Controller
    {
        // GET: Departments
        public ActionResult DepartmentCreate()
        {
            var vm = new DepartmentViewModel() { IsActive = true };
            return View(vm);
        }
    }
}