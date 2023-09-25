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
    public class UniversitysController : ApiController
    {
        public UniversityManager _manager;

        public UniversitysController()
        {
            _manager = new UniversityManager();
        }
        // GET: api/Universitys
        public IHttpActionResult Get()
        {
            try
            {
                var entity = _manager.GetAll();
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Universitys/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _manager.Get(id);
                if (entity == null)
                    return NotFound();
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Universitys
        public IHttpActionResult Post([FromBody]UniversityViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _manager.Add(vm);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("Input is not valid");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Universitys/5
        public IHttpActionResult Put(int id, [FromBody]UniversityViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _manager.Update(id,vm);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("Input is not valid");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Universitys/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _manager.Delete(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }
    }
}
