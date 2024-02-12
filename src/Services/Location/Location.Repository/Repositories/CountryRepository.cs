using Dapper;
using Location.Core.Entities;
using Location.Core.Repositories;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Location.API.Repositories;

public class CountryRepository : BaseRepository, ICountryRepository
{
    public CountryRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Country> CreateAsync(Country country)
    {

        //var cmd = "INSERT INTO country (name,code) VALUES (@Name,@Code) returning *;";
        var cmd = @"INSERT INTO countries (name,code,createdat) VALUES (@Name,@Code,@CreatedAt) returning *";
        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Name", country.Name);
        dynamicParameters.Add("Code", country.Code);
        dynamicParameters.Add("CreatedAt", DateTime.UtcNow, DbType.DateTime);
        var result=await _dbConnection.QueryFirstAsync<Country>(cmd, dynamicParameters);

        return result;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _dbConnection.ExecuteAsync("DELETE FROM countries WHERE id=@id", new { id });
    }

    public async Task<List<Country>> GetAllAsync()
    {
        var query="SELECT * FROM countries";
        var countries = await _dbConnection.QueryAsync<Country>(query);
        return countries.ToList();
    }

    public async Task<Country> GetByIdAsync(int id)
    {
        var query="SELECT * FROM countries WHERE id=@id";
        var country = await _dbConnection.QuerySingleOrDefaultAsync<Country>(query,new{id});
        return country;
    }

    public async Task<Country> UpdateAsync(Country country)
    {
        var cmd = "UPDATE countries SET name=@Name,code=@Code,updatedat=@UpdatedAt WHERE id=@id returning *";
        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Name", country.Name);
        dynamicParameters.Add("Code", country.Code);
        dynamicParameters.Add("UpdatedAt", DateTime.UtcNow, DbType.DateTime);
        dynamicParameters.Add("id", country.Id);
        return await _dbConnection.QuerySingleAsync<Country>(cmd, dynamicParameters);
    }
}