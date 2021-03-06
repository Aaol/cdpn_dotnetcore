using System.Linq;
using JokeApp.Contracts;
using JokeApp.Data;
using JokeApp.Data.Models;
using JokeApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace JokeApp.Controllers
{
    [Route("api/joke")]
    public class JokeController : BaseEntityApiController
    {
        public JokeController(IJokeService jokeService) : base()
        {
            this.Services.Add(jokeService);
        }

        [HttpGet("jokes")]
        public IActionResult GetJokes()
        {
            return this.GetAll<Joke>();
        }
        [HttpGet("jokes/full")]
        public IActionResult GetJokesWithCategories()
        {
            IJokeService service = this.Services.OfType<IJokeService>().First();
            return this.ResponseServiceFunction(service.GetJokesWithCategories);
        }
        [HttpPost("joke")]
        public IActionResult PostJoke([FromBody] Joke joke)
        {
            return this.AddOrUpdate(joke);
        }
        [HttpDelete("joke/{id}")]
        public IActionResult DeleteJoke(long id)
        {
            return this.Delete<Joke>(id);
        }
    }
}