using FluentValidation;

namespace Flora.Api.Features.Species.Delete
{
    public class DeleteSpeciesCommandValidator : AbstractValidator<DeleteSpeciesCommand>
    {
        public DeleteSpeciesCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
