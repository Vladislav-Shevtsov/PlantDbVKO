using AutoMapper;
using Flora.Api.Common.Abstractions;
using Flora.Api.Common.Exceptions;
using Flora.Api.Data;

namespace Flora.Api.Features.Species.Update
{
    public class UpdateSpeciesCommandHandler : ICommandHandler<UpdateSpeciesCommand, SpeciesResponseDto>
    {
        private readonly FloraDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateSpeciesCommandHandler(FloraDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SpeciesResponseDto> Handle(UpdateSpeciesCommand request, CancellationToken cancellationToken)
        {
            var species = await _dbContext.Species.FindAsync(new object[] { request.Id }, cancellationToken);

            if (species == null)
                throw new NotFoundException(nameof(Domain.Species), request.Id);

            species.ScientificName = request.ScientificName;
            species.Author = request.Author;
            species.Description = request.Description;
            species.TaxonomyId = request.TaxonomyId;

            _dbContext.Species.Update(species);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SpeciesResponseDto>(species);
        }
    }
}
