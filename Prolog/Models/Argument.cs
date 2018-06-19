using System.Collections.Generic;

namespace Prolog.Models
{
    public abstract class Argument : IHaveId
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<ArgumentPosition> Positions { get; set; }
    }
}