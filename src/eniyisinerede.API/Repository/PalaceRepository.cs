using Dapper;
using eniyisinerede.API.Models;

namespace eniyisinerede.API.Repository;

public class PalaceRepository : BaseRepository, IPalaceRepository
{
    public PalaceRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Palace> CreateAsync(Palace palace)
    {
        var cmd= "INSERT INTO palace (name, districtid,createdat) VALUES (@Name, @DistrictId,@CreatedAt) RETURNING *";
        var dynamicParameters= new DynamicParameters();
        dynamicParameters.Add("Name", palace.Name);
        dynamicParameters.Add("DistrictId", palace.DistrictId);
        dynamicParameters.Add("CreatedAt", DateTime.UtcNow);
        return await _dbConnection.QueryFirstOrDefaultAsync<Palace>(cmd, dynamicParameters);
    }

    public async Task<int> DeleteAsync(int id)
    {
        var cmd= "DELETE FROM palace WHERE id=@Id";
        return await _dbConnection.ExecuteAsync(cmd, new { id });
    }

    public async Task<List<Palace>> GetAllAsync()
    {
        var query= "SELECT * FROM palace";
        var palaces= await _dbConnection.QueryAsync<Palace>(query);
        return palaces.ToList();
    }

    public async Task<Palace> GetByIdAsync(int id)
    {
        var query= "SELECT * FROM palace WHERE id=@Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Palace>(query, new { id });
    }

    public async Task<Palace> UpdateAsync(Palace palace)
    {
        var cmd= "UPDATE palace SET name=@Name, districtid=@DistrictId, updatedat=@UpdatedAt WHERE id=@Id RETURNING *";
        var dynamicParameters= new DynamicParameters();
        dynamicParameters.Add("Name", palace.Name);
        dynamicParameters.Add("DistrictId", palace.DistrictId);
        dynamicParameters.Add("UpdatedAt", DateTime.UtcNow);
        dynamicParameters.Add("Id", palace.Id);
        return await _dbConnection.QueryFirstOrDefaultAsync<Palace>(cmd, dynamicParameters);
    }
}
