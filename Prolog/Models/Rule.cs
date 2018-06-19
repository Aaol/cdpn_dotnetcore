using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prolog.Models
{
    public class Rule : IHaveId
    {
        public long Id { get; set; }
        public Fact Response { get; set; }
        public long IdResponse{get;set;}
        [InverseProperty("Rule")]
        public ICollection<Fact> Facts { get; set; }
        override public string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in Facts)
            {
                builder.Append(item.ToString());
                builder.Append("&");
            }
            builder.Append("->");
            builder.Append(Response.ToString());
            return builder.ToString();
        }
    }
}