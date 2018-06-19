using System.Collections.Generic;
using System.Linq;
namespace Prolog.Models
{
    public class Fact : IHaveId
    {
        public long Id { get; set; }
        public ICollection<ArgumentPosition> ArgumentPositions { get; set; }
        public string Name { get; set; }
        public Fact()
        {
            this.ArgumentPositions = new List<ArgumentPosition>();
        }
    }
}