using Pims.Service.Manager;
using Pims.Core.ViewModel;

using System;
using System.Web.Http;
using Pims.Core.ViewModel.Setup_Module;

namespace EmpApp.Controllers.Api
{
    public class DesignationsController : ApiController
    {
        public DesignationManager _manager;

        public DesignationsController()
        {
            _manager = new DesignationManager();
        }
        // GET: api/Designations
        public IHttpActionResult Get()
        {
            try
            {
                var entites = _manager.GetAll();
                return Ok(entites);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Designations/5
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

        // POST: api/Designations
        public IHttpActionResult Post([FromBody] DeginationViewModel vm)
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
                    return BadRequest("input not valid");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Designations/5
        public IHttpActionResult Put(int id, [FromBody]DeginationViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = _manager.Update(vm);
                    return Ok(entity);
                }
                else
                {
                    return BadRequest("input not valid");
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Designations/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _manager.Delete(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

       
    }
}
