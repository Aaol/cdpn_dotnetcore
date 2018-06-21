using JokeApp.Data;
using JokeApp.Data.Models;

namespace JokeApp.Services
{
    public class JokeService : BaseEntityService<Joke>
    {
        public JokeService(ApplicationDbContext context) : base(context)
        {
        }
    }
}