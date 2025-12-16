using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flora.Api.Domain
{
    public class Taxonomy
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Rank { get; set; }
        public Guid? ParentId { get; set; }
        public Taxonomy? Parent { get; set; }
        public ICollection<Taxonomy> Children { get; set; } = new List<Taxonomy>();
        public ICollection<Species> Species { get; set; } = new List<Species>();
    }

}