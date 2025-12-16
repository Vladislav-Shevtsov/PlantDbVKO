using FluentValidation;

namespace Flora.Api.Features.Species.Create
{
    public class CreateSpeciesCommandValidator : AbstractValidator<CreateSpeciesCommand>
    {
        public CreateSpeciesCommandValidator()
        {
            RuleFor(x => x.ScientificName).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Author).MaximumLength(255);
            RuleFor(x => x.Description).MaximumLength(2000);
            RuleFor(x => x.TaxonomyId).NotEmpty();
        }
    }
}
