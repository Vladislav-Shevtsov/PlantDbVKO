using MediatR;
using Flora.Api.Features.Species.Create;
using Flora.Api.Features.Species.GetById;
using Flora.Api.Features.Species.List;

namespace Flora.Api.Features.Species
{
    public static class SpeciesEndpoints
    {
        public static void MapSpeciesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/species")
                .WithTags("Species");

            group.MapPost("/", CreateSpecies)
                .WithName("CreateSpecies")
                .WithOpenApi();

            group.MapGet("/{id}", GetSpeciesById)
                .WithName("GetSpeciesById")
                .WithOpenApi();

            group.MapGet("/", ListSpecies)
                .WithName("ListSpecies")
                .WithOpenApi();
        }

        private static async Task<IResult> CreateSpecies(
            CreateSpeciesCommand command,
            IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Results.Created($"/api/species/{result.Id}", result);
        }

        private static async Task<IResult> GetSpeciesById(
            Guid id,
            IMediator mediator)
        {
            var query = new GetSpeciesByIdQuery(id);
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        private static async Task<IResult> ListSpecies(
            IMediator mediator,
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null,
            Guid? taxonomyId = null)
        {
            var query = new ListSpeciesQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SearchTerm = searchTerm,
                TaxonomyId = taxonomyId
            };
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }
    }
}
