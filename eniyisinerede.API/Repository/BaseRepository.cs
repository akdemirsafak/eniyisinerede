using Npgsql;
using System.Data;

namespace eniyisinerede.API.Repository
{
    public class BaseRepository
    {
        protected readonly IConfiguration _configuration;
        protected readonly IDbConnection _dbConnection;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
