using Flora.Api.Common.Abstractions;

namespace Flora.Api.Features.Species.GetById
{
    public class GetSpeciesByIdQuery : IQuery<SpeciesResponseDto>
    {
        public Guid Id { get; set; }

        public GetSpeciesByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
