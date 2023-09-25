using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pims.Core.ViewModel.Setup_Module;
using Pims.Service.Manager;

namespace EmpApp.Controllers.Api
{
    public class OrganizationsController : ApiController
    {
        public OrganizationManager _OrganizationManager;

        public OrganizationsController()
        {
            _OrganizationManager = new OrganizationManager();
        }
        // GET: api/Organizations
        public IHttpActionResult Get()
        {
            try
            {
                var entites = _OrganizationManager.GetAll();
                return Ok(entites);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Organizations/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _OrganizationManager.Get(id);
                if (entity == null)
                    return NotFound();
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Organizations
        public IHttpActionResult Post([FromBody]OrganizationViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _OrganizationManager.Add(vm);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("Not found valid data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Organizations/5
        public IHttpActionResult Put(int id, [FromBody]OrganizationViewModel vm)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _OrganizationManager.Update(id,vm);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("Not found valid data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Organizations/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _OrganizationManager.Delete(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
