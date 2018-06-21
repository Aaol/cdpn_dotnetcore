using JokeApp.Data;
using JokeApp.Data.Models;
using JokeApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace JokeApp.Controllers 
{
    public class JokeController : BaseEntityApiController
    {
        public JokeController(IBaseEntityService<Joke> jokeService)
        {
            this.Services.Add(jokeService);
        }

        [HttpGet("jokes")]
        public IActionResult GetJokes()
        {
            return this.GetAll<Joke>();
        }

        [HttpPost("joke")]
        public IActionResult PostJoke([FromBody] Joke joke)
        {
            return this.AddOrUpdate(joke);
        }
    }
}