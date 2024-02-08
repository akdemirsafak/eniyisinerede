using Place.API.Models;
using SharedLibrary.Dtos;

namespace Place.API.Services;

public interface IPlaceService
{
    Task<ApiResponse<List<PlaceResponse>>> GetAsync();
    Task<ApiResponse<PlaceResponse>> GetByIdAsync(string id);
    Task<ApiResponse<PlaceResponse>> CreateAsync(CreatePlaceRequest createPlaceRequest);
    Task<ApiResponse<PlaceResponse>> UpdateAsync(string id, UpdatePlaceRequest updatePlaceRequest);
    Task<ApiResponse<NoContent>> RemoveAsync(string id);
}
