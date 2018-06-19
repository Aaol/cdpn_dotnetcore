using System.Collections.Generic;

namespace Prolog.Models
{
    public abstract class Argument : IHaveIdentifier
    {
        public long Identifier { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public byte Discriminator { get; set; }
        public ICollection<Fact> Facts { get; set; }
    }
}