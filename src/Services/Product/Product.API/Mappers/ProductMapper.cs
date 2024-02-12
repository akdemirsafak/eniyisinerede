using AutoMapper;
using Product.API.RequestModels;
using Product.API.ResponseModels;

namespace Product.API.Mappers;

public class ProductMapper:Profile
{
    public ProductMapper()
    {
        CreateMap<Entities.Product, ProductResponse>().ReverseMap();

        CreateMap<CreateProductRequest, Entities.Product>();
        CreateMap<Entities.Product, CreatedProductResponse>();

        CreateMap<UpdateProductRequest, Entities.Product>();
        CreateMap<Entities.Product, UpdatedProductResponse>();
    }
}
