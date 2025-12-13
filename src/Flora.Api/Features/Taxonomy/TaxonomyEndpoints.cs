using MediatR;
using Flora.Api.Features.Taxonomy.GetHierarchy;

namespace Flora.Api.Features.Taxonomy
{
    public static class TaxonomyEndpoints
    {
        public static void MapTaxonomyEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/taxonomy")
                .WithTags("Taxonomy");

            group.MapGet("/hierarchy", GetTaxonomyHierarchy)
                .WithName("GetTaxonomyHierarchy")
                .WithOpenApi();
        }

        private static async Task<IResult> GetTaxonomyHierarchy(IMediator mediator)
        {
            var query = new GetTaxonomyHierarchyQuery();
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }
    }
}
