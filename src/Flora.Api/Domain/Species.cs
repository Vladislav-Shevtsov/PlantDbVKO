using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Flora.Api.Domain
{
    public class Species
    {
        public Guid Id { get; set; }
        public string ScientificName { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public Guid TaxanomyId { get; set; }
        public Taxanomy Taxanomy { get; set; }
        public ICollection<Translation> Translations { get; set; } = new List<Translation>();
        public ICollection<Media> Media { get; set; } = new List<Media>();
        public ICollection<Sequence> Sequences { get; set; } = new List<Sequence>();
        public ICollection<Distribution> Distributions { get; set; } = new List<Distribution>();
        
    }
}