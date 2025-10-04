using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flora.Api.Domain
{
    public class Media
    {
    public Guid Id { get; set; } // PK
    public string Url { get; set; } // Or byte[] for blobs
    public string AltText { get; set; }
    public string Type { get; set; } // "Image", "Photo"
    public Guid SpeciesId { get; set; } // FK
    public Species Species { get; set; }
    }
}