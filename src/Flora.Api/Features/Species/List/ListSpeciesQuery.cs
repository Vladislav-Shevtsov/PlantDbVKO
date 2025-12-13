using Flora.Api.Common.Abstractions;

namespace Flora.Api.Features.Species.List
{
    public class ListSpeciesQuery : IQuery<List<SpeciesListItemDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; }
    }
}
