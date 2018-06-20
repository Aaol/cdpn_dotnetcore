using System;
using System.Collections.Generic;

namespace JokeApp.Models
{
    public class Joke
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<JokeCategory> JokeCategories { get; set; } = new List<JokeCategory>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public Author Author { get; set; }

    }
}