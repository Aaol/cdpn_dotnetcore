using System.Collections.Generic;
using JokeApp.Data.Models;

namespace JokeApp.Contracts
{
    public interface IJokeService : IBaseEntityService<Joke>
    {
        IEnumerable<Joke> GetJokesWithCategories();
    }
}