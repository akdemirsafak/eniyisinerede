using eniyisinerede.webui.ViewModels.Products;

namespace eniyisinerede.webui.Services.Interfaces;

public interface IProductService
{
    Task<ProductViewModel> CreateAsync(ProductViewModel productViewModel);
    Task<ProductViewModel> UpdateAsync(ProductViewModel productViewModel);
    Task<ProductViewModel> GetAsync(Guid productId);
    Task<List<ProductViewModel>> GetAllAsync();
    Task<bool> DeleteAsync(Guid productId);
}