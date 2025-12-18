using FluentValidation;

namespace Flora.Api.Features.Species.Update
{
    public class UpdateSpeciesCommandValidator : AbstractValidator<UpdateSpeciesCommand>
    {
        public UpdateSpeciesCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ScientificName).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Author).MaximumLength(255);
            RuleFor(x => x.Description).MaximumLength(2000);
            RuleFor(x => x.TaxonomyId).Must(BeValidGuidOrEmpty).WithMessage("TaxonomyId must be a valid GUID or empty.");
        }

        private bool BeValidGuidOrEmpty(string taxonomyId)
        {
            return string.IsNullOrEmpty(taxonomyId) || Guid.TryParse(taxonomyId, out _);
        }
    }
}
