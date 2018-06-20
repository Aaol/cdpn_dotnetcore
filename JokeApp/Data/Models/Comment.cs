using System;

namespace JokeApp.Data.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public virtual Author Author { get; set; }
        public virtual Joke Joke { get; set; }
        public string Message { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}