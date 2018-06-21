using System;
using JokeApp.Data;
using JokeApp.Data.Models;

namespace JokeApp.Services
{
    public class JokeService : BaseEntityService<Joke>
    {
        public JokeService(ApplicationDbContext context) : base(context)
        {
        }
        override protected void ActionOnAddOrUpdate(Joke value)
        {
            if(value.Id == 0)
            {
                value.CreationDate = DateTime.Now;
            }
            value.LastUpdateDate = DateTime.Now;
        }
    }
}