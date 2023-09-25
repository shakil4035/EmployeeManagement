using Pims.Service.Manager.OperationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pims.Core.ViewModel.Operation_module;

namespace EmpApp.Controllers.Api.Opration
{
    public class EducationsController : ApiController
    {
        public EducationManager _educationManager;

        public EducationsController()
        {
            _educationManager = new EducationManager();
        }
        // GET: api/Educations
        public IHttpActionResult Get()
        {
            try
            {
                var entitys = _educationManager.GetAll();
                return Ok(entitys);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Educations/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _educationManager.Get(id);
                if (entity == null)
                    return NotFound();
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Educations
        public IHttpActionResult Post([FromBody]EducationInfoViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(_educationManager.Add(vm));
                }
                else
                {
                    return BadRequest("input value not valid");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Educations/5
        public IHttpActionResult Put(int id, [FromBody]EducationInfoViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(_educationManager.Update(id,vm));
                }
                else
                {
                    return BadRequest("input value not valid");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Educations/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _educationManager.Delete(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
