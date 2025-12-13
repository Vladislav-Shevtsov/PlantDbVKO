namespace Flora.Api.Features.Distribution.GetBySpecies
{
    public class DistributionDetailDto
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? RegionCode { get; set; }
        public string? Source { get; set; }
        public DateTime CollectedDate { get; set; }
    }
}
