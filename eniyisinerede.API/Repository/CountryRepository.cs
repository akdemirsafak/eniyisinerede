using Dapper;
using eniyisinerede.API.Models;
using Npgsql;
using System.Data;

namespace eniyisinerede.API.Repository;

public class CountryRepository : BaseRepository, ICountryRepository
{
    public CountryRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Country> CreateAsync(Country country)
    {

            //var cmd = "INSERT INTO country (name,code) VALUES (@Name,@Code) returning *;";
            var cmd = @"INSERT INTO country (name,code,createdat) VALUES (@Name,@Code,@CreatedAt) returning *";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("Name", country.Name);
            dynamicParameters.Add("Code", country.Code);
            dynamicParameters.Add("CreatedAt", DateTime.UtcNow, DbType.DateTime);
            var result=await _dbConnection.QueryFirstAsync<Country>(cmd, dynamicParameters);

            return result;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _dbConnection.ExecuteAsync("DELETE FROM country WHERE id=@id", new { id });
    }

    public async Task<List<Country>> GetAllAsync()
    {
        var query="SELECT * FROM country";
        var countries = await _dbConnection.QueryAsync<Country>(query);
        return countries.ToList();
    }

    public async Task<Country> GetByIdAsync(int id)
    {
        var country = await _dbConnection.QueryFirstOrDefaultAsync<Country>("SELECT * FROM country where id=@id", id);
        return country;
    }

    public async Task<Country> UpdateAsync(Country country)
    {
        var cmd = "UPDATE country SET name=@Name,code=@Code,updatedat=@UpdatedAt WHERE id=@id returning *";
        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Name", country.Name);
        dynamicParameters.Add("Code", country.Code);
        dynamicParameters.Add("UpdatedAt", DateTime.UtcNow, DbType.DateTime);
        dynamicParameters.Add("id", country.Id);
        return await _dbConnection.QuerySingleAsync<Country>(cmd, dynamicParameters);
    }
}