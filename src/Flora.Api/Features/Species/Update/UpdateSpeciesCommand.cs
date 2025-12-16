using Flora.Api.Common.Abstractions;

namespace Flora.Api.Features.Species.Update
{
    public class UpdateSpeciesCommand : ICommand<Species.SpeciesResponseDto>
    {
        public Guid Id { get; set; }
        public string ScientificName { get; set; } = string.Empty;
        public string? Author { get; set; }
        public string? Description { get; set; }
        public Guid TaxonomyId { get; set; }
    }
}

