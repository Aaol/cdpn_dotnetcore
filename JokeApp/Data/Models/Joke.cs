using System;
using System.Collections.Generic;

namespace JokeApp.Data.Models
{
    public class Joke
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<JokeCategory> JokeCategories { get; set; } = new List<JokeCategory>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual Author Author { get; set; }

    }
}