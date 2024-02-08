using AutoMapper;
using MongoDB.Driver;
using Place.API.Models;
using Place.API.Mongo;
using SharedLibrary.Dtos;

namespace Place.API.Services;

public class PlaceService : IPlaceService
{
    private readonly IMongoCollection<Place.API.Models.Place> _placeCollection;
    private readonly IMapper _mapper;

    public PlaceService(IDatabaseSettings databaseSettings, IMapper mapper)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _placeCollection = database.GetCollection<Place.API.Models.Place>(databaseSettings.CollectionName);
        _mapper = mapper;
    }

    public async Task<ApiResponse<PlaceResponse>> CreateAsync(CreatePlaceRequest createPlaceRequest)
    {

        var place= _mapper.Map<Place.API.Models.Place>(createPlaceRequest);
        await _placeCollection.InsertOneAsync(place);

        var placeResponse = _mapper.Map<PlaceResponse>(place);

        return ApiResponse<PlaceResponse>.Success(placeResponse, 201);

    }

    public async Task<ApiResponse<List<PlaceResponse>>> GetAsync()
    {
        var places= await _placeCollection.Find(place => true).ToListAsync();


        var placesResponse = _mapper.Map<List<PlaceResponse>>(places);

        return ApiResponse<List<PlaceResponse>>.Success(placesResponse, 200);
    }

    public async Task<ApiResponse<PlaceResponse>> GetByIdAsync(string id)
    {
        var place= await _placeCollection.Find<Place.API.Models.Place>(x=>x.Id==id).FirstOrDefaultAsync();
        if (place is null)
        {
            return ApiResponse<PlaceResponse>.Fail("Place NotFound", 400);
        }
        var placeResponse= _mapper.Map<PlaceResponse>(place);

        return ApiResponse<PlaceResponse>.Success(placeResponse, 200);
    }

    public async Task<ApiResponse<NoContent>> RemoveAsync(string id)
    {
        var result = await _placeCollection.DeleteOneAsync(x=>x.Id==id);
        if(result.DeletedCount==0)
            return ApiResponse<NoContent>.Fail("Place could not be deleted", 500);
        
        return ApiResponse<NoContent>.Success(204);
    }

    public async Task<ApiResponse<PlaceResponse>> UpdateAsync(string id, UpdatePlaceRequest updatePlaceRequest)
    {
        var place= await _placeCollection.Find<Place.API.Models.Place>(x=>x.Id==id).FirstOrDefaultAsync();
        if (place is null)
            return ApiResponse<PlaceResponse>.Fail("Place NotFound", 400);


        place.Name = updatePlaceRequest.Name;
        place.Description = updatePlaceRequest.Description;
        place.Address = updatePlaceRequest.Address;
        var result =await _placeCollection.ReplaceOneAsync(x=>x.Id==id,place);
       
        if(result.ModifiedCount==0)
            return ApiResponse<PlaceResponse>.Fail("Place could not be updated", 500);

        var placeResponse= _mapper.Map<PlaceResponse>(place);
  
        return ApiResponse<PlaceResponse>.Success(placeResponse, 200);
    }
}
