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
    public class GeneralInformationsController : ApiController
    {
        public GeneralInfo _genetalInfo;

        public GeneralInformationsController()
        {
            _genetalInfo = new GeneralInfo();
        }

        [Route("api/GeneralInformations/SearchAutoComplete")]
        [HttpGet]
        public IHttpActionResult SearchAutoComplete(string pNumber)
        {
            try
            {
                var info = _genetalInfo.GetAll().SingleOrDefault(c => c.EmployeeId == pNumber);

                return Ok(info);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("api/GeneralInformations/Search")]
        [HttpGet]
        public IHttpActionResult Search(string query = null)
        {
            if (!String.IsNullOrWhiteSpace(query))
            {
                var a = _genetalInfo.GetAll().Where(c => c.EmployeeId.Contains(query)|| c.NameEnglish.Contains(query))
                    .ToList();
                return Ok(a);
            }
            return Ok(0);
        }

        [Route("api/GeneralInformations/GenerateEmployeId")]
        [HttpGet]
        public IHttpActionResult GenerateEmployeId()
        {
            try
            {
                var entities = _genetalInfo.GenerateEmployeId();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/GeneralInformations/GetInfoById")]
        [HttpGet]
        public IHttpActionResult GetInfoById(int id)
        {
            try
            {
                var entities = _genetalInfo.GetAll().Where(c => c.Id == id).ToList();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/GeneralInformations
        public IHttpActionResult Get()
        {
            try
            {
                var entities = _genetalInfo.GetAll();
                return Ok(entities);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/GeneralInformations/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                var entity = _genetalInfo.Get(id);
                if (entity == null)
                    return NotFound();
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // POST: api/GeneralInformations
        public IHttpActionResult Post([FromBody]GenarelInformationViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(_genetalInfo.Add(vm));
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

        // PUT: api/GeneralInformations/5
        public IHttpActionResult Put(int id, [FromBody]GenarelInformationViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(_genetalInfo.Update(id,vm));
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

        // DELETE: api/GeneralInformations/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var entity = _genetalInfo.Delete(id);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
