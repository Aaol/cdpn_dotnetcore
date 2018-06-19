using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prolog.Models
{
    public class Fact : IHaveId
    {
        public long Id { get; set; }
        public ICollection<ArgumentPosition> ArgumentPositions { get; set; }
        public string Name { get; set; }
        public Rule Rule { get; set; }
        public Rule RuleResponse { get; set; }
        public Fact()
        {
            this.ArgumentPositions = new List<ArgumentPosition>();
        }
        override public string ToString()
        {
            StringBuilder builder = new StringBuilder(Name);
            builder.Append("(");
            foreach (var item in ArgumentPositions.Take(ArgumentPositions.Count - 1))
            {
                builder.Append(item.Argument.Name);
                builder.Append(",");
            }
            if (ArgumentPositions.Count != 0)
            {
                builder.Append(ArgumentPositions.Last().Argument.Name);
            }
            builder.Append(")");
            return builder.ToString();
        }
    }
}