using Flora.Api.Common.Abstractions;
using Flora.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Flora.Api.Features.Taxonomy.GetHierarchy
{
    public class GetTaxonomyHierarchyQueryHandler : IQueryHandler<GetTaxonomyHierarchyQuery, List<TaxonomyNodeDto>>
    {
        private readonly FloraDbContext _dbContext;

        public GetTaxonomyHierarchyQueryHandler(FloraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaxonomyNodeDto>> Handle(GetTaxonomyHierarchyQuery request, CancellationToken cancellationToken)
        {
            var rootTaxonomies = await _dbContext.Taxonomies
                .Where(t => t.ParentId == null)
                .Include(t => t.Children)
                .Include(t => t.Species)
                .ToListAsync(cancellationToken);

            return rootTaxonomies.Select(t => MapToNodeDto(t)).ToList();
        }

        private TaxonomyNodeDto MapToNodeDto(Domain.Taxonomy taxonomy)
        {
            return new TaxonomyNodeDto
            {
                Id = taxonomy.Id,
                Name = taxonomy.Name,
                Rank = taxonomy.Rank,
                SpeciesCount = taxonomy.Species?.Count ?? 0,
                Children = taxonomy.Children?
                    .Select(c => MapToNodeDto(c))
                    .ToList() ?? new()
            };
        }
    }
}
