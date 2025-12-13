namespace Flora.Api.Features.Species.Create
{
    public class CreateSpeciesDto
    {
        public string ScientificName { get; set; } = string.Empty;
        public string? Author { get; set; }
        public string? Description { get; set; }
        public Guid TaxonomyId { get; set; }
    }
}
