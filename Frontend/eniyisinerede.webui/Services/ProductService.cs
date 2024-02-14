using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.ViewModels.Products;
using SharedLibrary.Dtos;

namespace eniyisinerede.webui.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ProductViewModel> CreateAsync(CreateProductViewModel createProductViewModel)
    {
        var clientResult=await _httpClient.PostAsJsonAsync("product", createProductViewModel);
        if (!clientResult.IsSuccessStatusCode)
            return null;

        var productViewModel = await clientResult.Content.ReadFromJsonAsync<ApiResponse<ProductViewModel>>();

        return productViewModel.Data;
    }

    public async Task<bool> DeleteAsync(Guid productId)
    {
        var clientResult =await _httpClient.DeleteAsync($"product/{productId}");
        if (!clientResult.IsSuccessStatusCode)
            return false;

        var clientContent = await clientResult.Content.ReadFromJsonAsync<ApiResponse<NoContent>>();
        if (clientContent.StatusCode != StatusCodes.Status204NoContent)
            return false;

        return true;

    }

    public async Task<ProductViewModel> GetAsync(Guid productId)
    {
        var product= await _httpClient.GetAsync($"product/{productId}");
        if (!product.IsSuccessStatusCode)
            return null;
        var productViewModel = await product.Content.ReadFromJsonAsync<ApiResponse<ProductViewModel>>();
        return productViewModel.Data;
    }

    public async Task<List<ProductViewModel>> GetAllAsync()
    {
        var products = await _httpClient.GetAsync("product");
        if (!products.IsSuccessStatusCode)
            return null;
        var productViewModel = await products.Content.ReadFromJsonAsync<ApiResponse<List<ProductViewModel>>>();
        return productViewModel.Data;
    }

    public async Task<ProductViewModel> UpdateAsync(UpdateProductViewModel updateProductViewModel)
    {
        var clientResult =await _httpClient.PutAsJsonAsync($"product/{updateProductViewModel.Id}", updateProductViewModel);

        if (!clientResult.IsSuccessStatusCode)
            return null;

        var productViewModel = await clientResult.Content.ReadFromJsonAsync<ApiResponse<ProductViewModel>>();

        return productViewModel.Data;
    }
}