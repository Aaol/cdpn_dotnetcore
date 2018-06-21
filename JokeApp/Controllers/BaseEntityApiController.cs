using System;
using System.Collections.Generic;
using JokeApp.Data;
using JokeApp.Data.Models;
using JokeApp.Helpers;
using JokeApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace JokeApp.Controllers
{
    public abstract class BaseEntityApiController : ControllerBase
    {
        public ICollection<IBaseService> Services { get; set; }
        public BaseEntityApiController()
        {
            this.Services = new List<IBaseService>();
        }


        protected EntityResponse<T> CreateResponse<T>(T value, ICollection<string> errors, string success)
        {
            EntityResponse<T> response = new EntityResponse<T>();
            response.Entity = value;
            response.Errors = errors;
            response.Success = success;
            return response;
        }
        protected IActionResult NewResponse<T>(EntityResponse<T> response)
        {
            if(response.HasErrors())
            {
                return Ok(response);
            }
            else
            {
                return StatusCode(400, response);
            }
        }

        protected IActionResult GetAll<T>(string success = null)
            where T: class, IHaveID
        {
            IBaseEntityService<T> service = this.Services.OfType<IBaseEntityService<T>>().First();
            ICollection<string> errors = new List<string>();
            IEnumerable<T> entity = new List<T>();
            try
            {
                entity = service.FindAll();  
            }
            catch (System.Exception e)
            {
                errors.Add(e.Message);
            }
            return NewResponse(CreateResponse(entity, errors, success));
        }
        protected IActionResult GetOne<T>(long id, string success = null)
            where T: class, IHaveID
        {
            IBaseEntityService<T> service = this.Services.OfType<IBaseEntityService<T>>().First();
            ICollection<string> errors = new List<string>();
            T entity = null;
            try
            {
                entity = service.FindById(id);  
            }
            catch (System.Exception e)
            {
                errors.Add(e.Message);
            }
            return NewResponse(CreateResponse(entity, errors, success));
        }
        protected IActionResult Delete<T>(long id, string success = null)
            where T: class, IHaveID
        {
            IBaseEntityService<T> service = this.Services.OfType<IBaseEntityService<T>>().First();
            ICollection<string> errors = new List<string>();
            bool entity = false;
            try
            {
                entity = service.Delete(id);  
            }
            catch (System.Exception e)
            {
                errors.Add(e.Message);
            }
            return NewResponse(CreateResponse(entity, errors, success));
        }
        protected IActionResult AddOrUpdate<T>(T value, string success = null)
            where T: class, IHaveID
        {
            IBaseEntityService<T> service = this.Services.OfType<IBaseEntityService<T>>().First();
            ICollection<string> errors = new List<string>();
            T entity = null;
            try
            {
                entity = service.AddOrUpdate(value);  
            }
            catch (System.Exception e)
            {
                errors.Add(e.Message);
            }
            return NewResponse(CreateResponse(entity, errors, success));
        }
    }
}