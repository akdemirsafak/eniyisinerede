using AutoMapper;
using Product.API.Repositories;
using Product.API.RequestModels;
using Product.API.ResponseModels;
using SharedLibrary.Dtos;

namespace Product.API.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<CreatedProductResponse>> CreateAsync(CreateProductRequest productDto)
    {
        var product = _mapper.Map<Entities.Product>(productDto);
        await _productRepository.CreateAsync(product);
        return ApiResponse<CreatedProductResponse>.Success(_mapper.Map<CreatedProductResponse>(product),201);
    }

    public async Task<ApiResponse<NoContent>> DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
        return ApiResponse<NoContent>.Success(204);
    }

    public async Task<ApiResponse<List<ProductResponse>>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();
  
        return ApiResponse<List<ProductResponse>>.Success(_mapper.Map<List<ProductResponse>>(products));
    }

    public async Task<ApiResponse<ProductResponse>> GetByIdAsync(Guid id)
    {
        var product=await _productRepository.GetByIdAsync(id);
        return ApiResponse<ProductResponse>.Success(_mapper.Map<ProductResponse>(product));
    }

    public async Task<ApiResponse<UpdatedProductResponse>> UpdateAsync(Guid id, UpdateProductRequest productDto)
    {
        var product= _mapper.Map<Entities.Product>(productDto);
        product.Id=id;
        await _productRepository.UpdateAsync(product);

        return ApiResponse<UpdatedProductResponse>.Success(_mapper.Map<UpdatedProductResponse>(product));
    }
}
