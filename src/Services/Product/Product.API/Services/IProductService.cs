using Product.API.RequestModels;
using Product.API.ResponseModels;
using SharedLibrary.Dtos;

namespace Product.API.Services;

public interface IProductService
{
    Task<ApiResponse<List<ProductResponse>>> GetAllAsync();
    Task<ApiResponse<ProductResponse>> GetByIdAsync(Guid id);
    Task<ApiResponse<CreatedProductResponse>> CreateAsync(CreateProductRequest productDto);
    Task<ApiResponse<UpdatedProductResponse>> UpdateAsync(Guid id, UpdateProductRequest productDto);
    Task<ApiResponse<NoContent>> DeleteAsync(Guid id);
}
