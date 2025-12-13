using AutoMapper;
using Flora.Api.Common.Abstractions;
using Flora.Api.Common.Exceptions;
using Flora.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Flora.Api.Features.Species.GetById
{
    public class GetSpeciesByIdQueryHandler : IQueryHandler<GetSpeciesByIdQuery, SpeciesResponseDto>
    {
        private readonly FloraDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSpeciesByIdQueryHandler(FloraDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SpeciesResponseDto> Handle(GetSpeciesByIdQuery request, CancellationToken cancellationToken)
        {
            var species = await _dbContext.Species
                .Include(s => s.Translations)
                .Include(s => s.Media)
                .Include(s => s.Distributions)
                .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (species == null)
                throw new NotFoundException(nameof(Domain.Species), request.Id);

            return _mapper.Map<SpeciesResponseDto>(species);
        }
    }
}
