using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JokeApp.Models
{
    public class Author
    {
        public long Id { get; set; }
        public string NickName { get; set; }
        public IdentityUser User { get; set; }
        public ICollection<Joke> Jokes { get; set; } = new List<Joke>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}