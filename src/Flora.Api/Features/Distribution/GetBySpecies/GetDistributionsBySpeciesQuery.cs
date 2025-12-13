using Flora.Api.Common.Abstractions;

namespace Flora.Api.Features.Distribution.GetBySpecies
{
    public class GetDistributionsBySpeciesQuery : IQuery<List<DistributionDetailDto>>
    {
        public Guid SpeciesId { get; set; }

        public GetDistributionsBySpeciesQuery(Guid speciesId)
        {
            SpeciesId = speciesId;
        }
    }
}
