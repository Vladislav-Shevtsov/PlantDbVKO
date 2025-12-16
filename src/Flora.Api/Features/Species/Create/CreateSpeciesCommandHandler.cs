using AutoMapper;
using Flora.Api.Common.Abstractions;
using Flora.Api.Data;
using Flora.Api.Domain;

namespace Flora.Api.Features.Species.Create
{
    public class CreateSpeciesCommandHandler : ICommandHandler<CreateSpeciesCommand, SpeciesResponseDto>
    {
        private readonly FloraDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateSpeciesCommandHandler(FloraDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SpeciesResponseDto> Handle(CreateSpeciesCommand request, CancellationToken cancellationToken)
        {
            var species = new Domain.Species
            {
                Id = Guid.NewGuid(),
                ScientificName = request.ScientificName,
                Author = request.Author,
                Description = request.Description,
                TaxonomyId = request.TaxonomyId
            };

            _dbContext.Species.Add(species);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<SpeciesResponseDto>(species);
        }
    }
}
