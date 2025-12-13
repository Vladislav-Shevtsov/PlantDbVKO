namespace Flora.Api.Features.Species
{
    public class SpeciesResponseDto
    {
        public Guid Id { get; set; }
        public string ScientificName { get; set; } = string.Empty;
        public string? Author { get; set; }
        public string? Description { get; set; }
        public Guid TaxonomyId { get; set; }
        public List<TranslationDto> Translations { get; set; } = new();
        public List<MediaDto> Media { get; set; } = new();
        public List<DistributionDto> Distributions { get; set; } = new();
    }

    public class SpeciesListItemDto
    {
        public Guid Id { get; set; }
        public string ScientificName { get; set; } = string.Empty;
        public string? Author { get; set; }
    }

    public class TranslationDto
    {
        public Guid Id { get; set; }
        public string LanguageCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? TerrainDescription { get; set; }
    }

    public class MediaDto
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string? AltText { get; set; }
        public string Type { get; set; } = string.Empty;
    }

    public class DistributionDto
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? RegionCode { get; set; }
        public string? Source { get; set; }
        public DateTime CollectedDate { get; set; }
    }
}
