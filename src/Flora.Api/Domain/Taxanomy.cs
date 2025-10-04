using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flora.Api.Domain
{
    public class Taxanomy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public Guid? ParentId { get; set; }
        public Taxanomy Parent { get; set; }
        public ICollection<Taxanomy> Children { get; set; } = new List<Taxanomy>();
        public ICollection<Species> Species { get; set; } 
    }

}