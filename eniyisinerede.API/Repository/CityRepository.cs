using Dapper;
using eniyisinerede.API.Models;
using System.Data;

namespace eniyisinerede.API.Repository;

public class CityRepository : BaseRepository, ICityRepository
{
    public CityRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<City> CreateAsync(City city)
    {
        var checkCountry = await _dbConnection.ExecuteScalarAsync<int>("SELECT Count(*) FROM country WHERE id=@id", new { id=city.CountryId });
        if(checkCountry==0)
            throw new Exception("Country not found");


        string cmd="INSERT INTO city (name, countryid,createdat) VALUES (@Name, @CountryId,@CreatedAt) RETURNING *";
        DynamicParameters parameters = new();
        parameters.Add("Name", city.Name,DbType.String);
        parameters.Add("CountryId", city.CountryId);
        parameters.Add("CreatedAt",city.CreatedAt,DbType.DateTime);
        return await _dbConnection.QueryFirstAsync<City>(cmd, parameters);
    }

    public async Task<int> DeleteAsync(int id)
    {
        string cmd="DELETE FROM city WHERE id=@id";
        return await _dbConnection.ExecuteAsync(cmd, new { id });
    }

    public async Task<List<City>> GetAllAsync()
    {
        string query="SELECT * FROM city";
        var cities= await _dbConnection.QueryAsync<City>(query);
        return cities.ToList();
    }

    public async Task<City> GetByIdAsync(int id)
    {
        string query="SELECT * FROM city WHERE id=@id";
        return await _dbConnection.QuerySingleOrDefaultAsync<City>(query, new { id });
    }

    public async Task<City> UpdateAsync(City city)
    {
        var checkCountry = await _dbConnection.ExecuteScalarAsync<int>("SELECT Count(*) FROM country WHERE id=@id", new { id=city.CountryId });
        if (checkCountry == 0)
            throw new Exception("Country not found");

        var cmd = "UPDATE city SET name=@Name, countryid=@CountryId, updatedat=@UpdatedAt WHERE id=@Id returning *";
        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Name", city.Name,DbType.String);
        dynamicParameters.Add("CountryId", city.CountryId);
        dynamicParameters.Add("UpdatedAt", city.UpdatedAt,DbType.DateTime);
        dynamicParameters.Add("Id", city.Id);
        return await _dbConnection.QueryFirstOrDefaultAsync<City>(cmd, dynamicParameters);
    }
}
