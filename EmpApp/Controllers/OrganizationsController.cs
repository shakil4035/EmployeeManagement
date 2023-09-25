using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Pims.Core.ViewModel.Setup_Module;

namespace EmpApp.Controllers
{
    public class OrganizationsController : Controller
    {
        // GET: Organizations
        public ActionResult New()
        {
            var organization = new OrganizationViewModel()
            {
                IsActive = true
            };
            return View(organization);
        }
    }
}