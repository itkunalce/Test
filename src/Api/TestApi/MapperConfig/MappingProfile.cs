using AutoMapper;
using Test.Entities.Models;
using Test.Shared.Dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestApi.MapperConfig;

public class MappingProfile : Profile
{
    public MappingProfile ()
    {
        CreateMap<Section, SectionDto>().ReverseMap();
        CreateMap<SectionForCreationDto, Section>();

        CreateMap<Subsection, SubsectionDto>().ReverseMap();
        CreateMap<ImageFormat, ImageFormatDto>().ReverseMap();
        CreateMap<Multimedia, MultimediaDto>().ReverseMap();
        CreateMap<Facet, FacetDto>().ReverseMap();
        CreateMap<ArticleFacet, ArticleFacetDto>().ReverseMap();
        CreateMap<Article, ArticleDto>().ReverseMap();
    }
}
