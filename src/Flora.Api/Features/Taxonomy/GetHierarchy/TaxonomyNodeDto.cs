namespace Flora.Api.Features.Taxonomy.GetHierarchy
{
    public class TaxonomyNodeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Rank { get; set; } = string.Empty;
        public int SpeciesCount { get; set; }
        public List<TaxonomyNodeDto> Children { get; set; } = new();
    }
}
