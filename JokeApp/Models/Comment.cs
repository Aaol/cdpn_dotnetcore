using System;

namespace JokeApp.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public Author Author { get; set; }
        public Joke Joke { get; set; }
        public string Message { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}