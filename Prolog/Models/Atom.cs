namespace Prolog.Models
{
    public class Atom : Argument
    {
        public Atom()
        {
            this.Discriminator = 1;
        }
    }
}