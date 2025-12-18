using AutoMapper;
using Flora.Api.Common.Abstractions;
using Flora.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Flora.Api.Features.Species.List
{
    public class ListSpeciesQueryHandler : IQueryHandler<ListSpeciesQuery, List<SpeciesListItemDto>>
    {
        private readonly FloraDbContext _dbContext;
        private readonly IMapper _mapper;

        public ListSpeciesQueryHandler(FloraDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<SpeciesListItemDto>> Handle(ListSpeciesQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Species.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                query = query.Where(s => s.ScientificName.Contains(request.SearchTerm));
            }

            if (request.TaxonomyId.HasValue)
            {
                query = query.Where(s => s.TaxonomyId == request.TaxonomyId.Value);
            }

            var species = await query
                .OrderBy(s => s.ScientificName)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<SpeciesListItemDto>>(species);
        }
    }
}
