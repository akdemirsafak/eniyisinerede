using eniyisinerede.webui.ViewModels.Products;

namespace eniyisinerede.webui.Services.Interfaces;

public interface IProductService
{
    Task<ProductViewModel> CreateAsync(CreateProductViewModel createProductViewModel);
    Task<ProductViewModel> UpdateAsync(UpdateProductViewModel updateProductViewModel);
    Task<ProductViewModel> GetAsync(Guid productId);
    Task<List<ProductViewModel>> GetAllAsync();
    Task<bool> DeleteAsync(Guid productId);
}