using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flora.Api.Domain
{
    public class Translation
    {
        public Guid Id { get; set; }
        public string LanguageCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TerrainDescription { get; set; }
        public Guid SpeciesId { get; set; }
        public Species Species { get; set; }
        
    }
}