namespace DayanaWeb.Server.Basic.Classes;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductCategoryEntity, ProductCategoryDto>().ReverseMap();
        CreateMap<ProductEntity, ProductDto>().ReverseMap();
        CreateMap<PaginatedList<ProductCategoryDto>, PaginatedList<ProductCategoryEntity>>().ReverseMap();
    }
}