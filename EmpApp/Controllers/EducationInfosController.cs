using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pims.Core.Model.OperationModules;
using Pims.Core.Model.SetupModule;

namespace EmpApp.Controllers
{
    public class EducationInfosController : Controller
    {
        // GET: EducationInfos
        public ActionResult EducationInfoCreate(int? id)
        {
            ViewBag.UniversityId= new SelectList(new List<University>(), "Id", "Name");
            //ViewBag.GenarelInformationId= new SelectList(new List<GenarelInformation>(), "Id", "Name");
            return View();
        }
    }
}