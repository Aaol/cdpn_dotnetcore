using System;
using System.Collections.Generic;
using System.Reflection;
using JokeApp.Data;
using JokeApp.Data.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using JokeApp.Contracts;

namespace JokeApp.Services
{
    public class JokeService : BaseEntityService<Joke>, IJokeService
    {
        public JokeService(ApplicationDbContext context) : base(context)
        {

        }
        override protected void ActionOnAddOrUpdate(Joke value)
        {
            if (value.Id == 0)
            {
                value.CreationDate = DateTime.Now;
            }
            value.LastUpdateDate = DateTime.Now;
        }
        public IEnumerable<Joke> GetJokesWithCategories()
        {
            return this.FindAllIncludable()
            .Include(j => j.JokeCategories)
            .ThenInclude(j => j.Category);
        }
    }
}