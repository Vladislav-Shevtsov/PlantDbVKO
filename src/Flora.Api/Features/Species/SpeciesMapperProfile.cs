using AutoMapper;
using Flora.Api.Domain;

namespace Flora.Api.Features.Species
{
    public class SpeciesMapperProfile : Profile
    {
        public SpeciesMapperProfile()
        {
            CreateMap<Domain.Species, SpeciesResponseDto>()
                .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
                .ForMember(dest => dest.Media, opt => opt.MapFrom(src => src.Media))
                .ForMember(dest => dest.Distributions, opt => opt.MapFrom(src => src.Distributions));

            CreateMap<Domain.Species, SpeciesListItemDto>();

            CreateMap<Translation, TranslationDto>();

            CreateMap<Media, MediaDto>();

            CreateMap<Domain.Distribution, DistributionDto>()
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Y))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.X));
        }
    }
}
