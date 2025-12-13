using Flora.Api.Common.Abstractions;

namespace Flora.Api.Features.Species.Delete
{
    public class DeleteSpeciesCommand : ICommand
    {
        public Guid Id { get; set; }

        public DeleteSpeciesCommand(Guid id)
        {
            Id = id;
        }
    }
}
