using AutoMapper;
using eniyisinerede.webui.ViewModels.Products;

namespace eniyisinerede.webui.Mappers.Products;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<ProductViewModel, CreateProductViewModel>().ReverseMap();
        CreateMap<ProductViewModel, UpdateProductViewModel>().ReverseMap();
    }
}
