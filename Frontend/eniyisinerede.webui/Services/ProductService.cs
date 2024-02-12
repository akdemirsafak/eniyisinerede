using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels;
using eniyisinerede.webui.ViewModels.Products;
using SharedLibrary.Dtos;

namespace eniyisinerede.webui.Services;

public class ProductService : IProductService
{
    //private HttpClient _httpClient= new HttpClient { BaseAddress = new Uri("https://localhost:5012/api/") };

    //public ProductService(HttpClient httpClient)
    //{
    //    _httpClient = httpClient;
    //}

    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<bool> CreateAsync(CreateProductViewModel createProductViewModel)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductViewModel> GetAsync(Guid productId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductViewModel>> GetAllAsync()
    {
        var products = await _httpClient.GetAsync("product");
        if (!products.IsSuccessStatusCode)
            return null;
        var productViewModel = await products.Content.ReadFromJsonAsync<ApiResponse<List<ProductViewModel>>>();
        return productViewModel.Data;
    }

    public Task<bool> UpdateAsync(UpdateProductViewModel updateProductViewModel)
    {
        throw new NotImplementedException();
    }
}