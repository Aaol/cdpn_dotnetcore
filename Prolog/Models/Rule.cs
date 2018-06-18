using System.Collections.Generic;

namespace Prolog.Models
{
    public class Rule
    {
        public long Identifier { get; set; }
        public Fact Response { get; set; }
        public ICollection<Fact> Facts { get; set; }
    }
}