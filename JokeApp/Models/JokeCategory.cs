namespace JokeApp.Models
{
    public class JokeCategory
    {
        public long Id { get; set; }
        public Joke Joke { get; set; }
        public Category Category { get; set; }
    }
}