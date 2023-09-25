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
    public class LanguagesController : ApiController
    {
        public LanguageManager _manager;

        public LanguagesController()
        {
            _manager = new LanguageManager();
        }
        // GET: api/Languages
        public IHttpActionResult Get()
        {
            try
            {
                var entites = _manager.GetAll();
                return Ok(entites);
            }
            catch (Exception e )
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Languages/5
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

        // POST: api/Languages
        public IHttpActionResult Post([FromBody]LanguageViewModel vm)
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

        // PUT: api/Languages/5
        public IHttpActionResult Put(int id, [FromBody]LanguageViewModel vm)
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
                    return BadRequest("input not valid");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Languages/5
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
