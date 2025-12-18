using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetTopologySuite.Geometries;
namespace Flora.Api.Domain
{
    public class Distribution
    {
        public Guid Id { get; set; }
        public string? Location { get; set; } // Temporarily string for lat,lon
        public string? RegionCode { get; set; }
        public string? Source { get; set; }
        public DateTime CollectedDate { get; set; }
        public Guid SpeciesId { get; set; }
        public Species? Species { get; set; }

    }
}