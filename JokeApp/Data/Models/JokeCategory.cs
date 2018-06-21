namespace JokeApp.Data.Models
{
    public class JokeCategory : IHaveID
    {
        public long Id { get; set; }
        public virtual Joke Joke { get; set; }
        public virtual Category Category { get; set; }
    }
}