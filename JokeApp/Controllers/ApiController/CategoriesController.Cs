using JokeApp.Contracts;
using JokeApp.Data.Models;
using JokeApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace JokeApp.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : BaseEntityApiController
    {
        public CategoriesController(IBaseEntityService<Category> service)
        {
            this.Services.Add(service);
        }
        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            return this.GetAll<Category>();
        }
    }
}