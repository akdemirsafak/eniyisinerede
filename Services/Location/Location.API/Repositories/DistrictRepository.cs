using Dapper;
using Location.API.Models;

namespace Location.API.Repositories;

public class DistrictRepository : BaseRepository, IDistrictRepository
{
    public DistrictRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<District> CreateAsync(District district)
    {
        var cmd = "INSERT INTO District (Name, ZipCode, CityId,CreatedAt) VALUES (@Name, @ZipCode, @CityId,@CreatedAt) RETURNING *";

        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Name", district.Name);
        dynamicParameters.Add("ZipCode", district.ZipCode);
        dynamicParameters.Add("CityId", district.CityId);
        dynamicParameters.Add("CreatedAt", DateTime.UtcNow);

        return await _dbConnection.QueryFirstOrDefaultAsync<District>(cmd, dynamicParameters);

    }

    public async Task<int> DeleteAsync(int id)
    {
        var cmd="DELETE FROM District WHERE Id=@Id";
        return await _dbConnection.ExecuteAsync(cmd, new { Id = id });
    }

    public async Task<List<District>> GetAllAsync()
    {
        var districts= await _dbConnection.QueryAsync<District>("SELECT * FROM District");
        return districts.ToList();
    }

    public async Task<District> GetByIdAsync(int id)
    {
        var query="SELECT * FROM District WHERE Id=@Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<District>(query, new { Id = id });
    }

    public async Task<District> UpdateAsync(District district)
    {
        var cmd = "UPDATE District SET Name=@Name, ZipCode=@ZipCode, CityId=@CityId, UpdatedAt=@UpdatedAt WHERE Id=@Id RETURNING *";
        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Name", district.Name);
        dynamicParameters.Add("ZipCode", district.ZipCode);
        dynamicParameters.Add("CityId", district.CityId);
        dynamicParameters.Add("UpdatedAt", DateTime.UtcNow, System.Data.DbType.DateTime);
        dynamicParameters.Add("Id", district.Id);

        return await _dbConnection.QueryFirstOrDefaultAsync<District>(cmd, dynamicParameters);
    }
}
