using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JokeApp.Data.Models
{
    public class Author
    {
        public long Id { get; set; }
        public string NickName { get; set; }
        public virtual IdentityUser User { get; set; }
        public virtual ICollection<Joke> Jokes { get; set; } = new List<Joke>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}