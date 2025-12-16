using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flora.Api.Domain
{
    public class Sequence
    {
    public Guid Id { get; set; } // PK
    public string? Accession { get; set; } // e.g., "MW409526.1"
    public string? Data { get; set; } // FASTA text (or blob for large files)
    public int Length { get; set; }
    public Guid SpeciesId { get; set; } // FK
    public Species? Species { get; set; }
    }
}