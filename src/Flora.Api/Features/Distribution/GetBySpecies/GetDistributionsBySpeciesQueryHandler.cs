using AutoMapper;
using Flora.Api.Common.Abstractions;
using Flora.Api.Common.Exceptions;
using Flora.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Flora.Api.Features.Distribution.GetBySpecies
{
    public class GetDistributionsBySpeciesQueryHandler : IQueryHandler<GetDistributionsBySpeciesQuery, List<DistributionDetailDto>>
    {
        private readonly FloraDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDistributionsBySpeciesQueryHandler(FloraDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<DistributionDetailDto>> Handle(GetDistributionsBySpeciesQuery request, CancellationToken cancellationToken)
        {
            // Verify species exists
            var speciesExists = await _dbContext.Species.AnyAsync(s => s.Id == request.SpeciesId, cancellationToken);
            if (!speciesExists)
                throw new NotFoundException(nameof(Domain.Species), request.SpeciesId);

            var distributions = await _dbContext.Distributions
                .Where(d => d.SpeciesId == request.SpeciesId)
                .ToListAsync(cancellationToken);

            return distributions.Select(d => new DistributionDetailDto
            {
                Id = d.Id,
                Latitude = d.Location.Y,
                Longitude = d.Location.X,
                RegionCode = d.RegionCode,
                Source = d.Source,
                CollectedDate = d.CollectedDate
            }).ToList();
        }
    }
}
