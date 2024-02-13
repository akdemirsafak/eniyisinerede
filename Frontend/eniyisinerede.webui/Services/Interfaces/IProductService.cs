using eniyisinerede.webui.ViewModels.Products;

namespace eniyisinerede.webui.Services.Interfaces;

public interface IProductService
{
    Task<bool> CreateAsync(CreateProductViewModel createProductViewModel);
    Task<bool> UpdateAsync(UpdateProductViewModel updateProductViewModel);
    Task<ProductViewModel> GetAsync(Guid productId);
    Task<List<ProductViewModel>> GetAllAsync();
    Task<bool> DeleteAsync(Guid productId);
}