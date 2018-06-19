using System.Collections.Generic;

namespace Prolog.Models
{
    public class Rule : IHaveId
    {
        public long Id { get; set; }
        public Fact Response { get; set; }
        public ICollection<Fact> Facts { get; set; }
    }
}