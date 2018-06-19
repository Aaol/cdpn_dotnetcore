using System.Collections.Generic;
using System.Linq;
namespace Prolog.Models
{
    public class Fact : IHaveIdentifier
    {
        public long Identifier { get; set; }
        public Rule Rule { get; set; }
        public ICollection<Argument> Arguments { get; set; }
        public string Name { get; set; }
        public Fact()
        {
            this.Arguments = new List<Argument>();
        }
    }
}