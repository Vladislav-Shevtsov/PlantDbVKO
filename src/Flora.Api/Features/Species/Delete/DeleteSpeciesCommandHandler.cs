using Flora.Api.Common.Abstractions;
using Flora.Api.Common.Exceptions;
using Flora.Api.Data;

namespace Flora.Api.Features.Species.Delete
{
    public class DeleteSpeciesCommandHandler : ICommandHandler<DeleteSpeciesCommand>
    {
        private readonly FloraDbContext _dbContext;

        public DeleteSpeciesCommandHandler(FloraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteSpeciesCommand request, CancellationToken cancellationToken)
        {
            var species = await _dbContext.Species.FindAsync(new object[] { request.Id }, cancellationToken);

            if (species == null)
                throw new NotFoundException(nameof(Domain.Species), request.Id);

            _dbContext.Species.Remove(species);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
