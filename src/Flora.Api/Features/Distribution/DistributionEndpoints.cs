using MediatR;
using Flora.Api.Features.Distribution.GetBySpecies;

namespace Flora.Api.Features.Distribution
{
    public static class DistributionEndpoints
    {
        public static void MapDistributionEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/distributions")
                .WithTags("Distributions");

            group.MapGet("/species/{speciesId}", GetDistributionsBySpecies)
                .WithName("GetDistributionsBySpecies")
                .WithOpenApi();
        }

        private static async Task<IResult> GetDistributionsBySpecies(
            Guid speciesId,
            IMediator mediator)
        {
            var query = new GetDistributionsBySpeciesQuery(speciesId);
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }
    }
}
