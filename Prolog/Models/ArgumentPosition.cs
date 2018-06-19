namespace Prolog.Models
{
    public class ArgumentPosition
    {
        public long Id { get; set; }
        public int Rank { get; set; }
        public Fact Fact { get; set; }
        public Argument Argument { get; set; }
    }
}