using Flora.Api.Common.Abstractions;

namespace Flora.Api.Features.Species.Create
{
    public class CreateSpeciesCommand : ICommand<SpeciesResponseDto>
    {
        public string ScientificName { get; set; } = string.Empty;
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string TaxonomyId { get; set; } = string.Empty;
    }
}
