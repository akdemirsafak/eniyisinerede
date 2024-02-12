using Dapper;
using eniyisinerede.API.Models;

namespace eniyisinerede.API.Repository;

public class CommentRepository : BaseRepository, ICommentRepository
{
    public CommentRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Comment> CreateAsync(Comment comment)
    {
        var cmd="INSERT INTO comments (header, body, palaceid,createdat) VALUES (@Header, @Body, @PalaceId,@CreatedAt) RETURNING *";
        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Header", comment.Header);
        dynamicParameters.Add("Body", comment.Body);
        dynamicParameters.Add("PalaceId", comment.PalaceId);
        dynamicParameters.Add("CreatedAt", DateTime.UtcNow);

        var result= await _dbConnection.QueryFirstOrDefaultAsync<Comment>(cmd, dynamicParameters);
        return result;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var cmd="DELETE FROM comments WHERE id=@Id";
        return await _dbConnection.ExecuteAsync(cmd, new { Id = id });

    }

    public async Task<List<Comment>> GetAllAsync()
    {
        var query = "SELECT * FROM comment";
        var comments= await _dbConnection.QueryAsync<Comment>(query);
        return comments.ToList();
    }

    public async Task<Comment> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM comment WHERE id=@Id";
        return await _dbConnection.QueryFirstOrDefaultAsync<Comment>(query, new { Id = id });
    }

    public async Task<Comment> UpdateAsync(Comment comment)
    {
        var cmd="UPDATE comments SET header=@Header, body=@Body, palaceid=@PalaceId, updatedat=@UpdatedAt WHERE id=@Id RETURNING *";
        var dynamicParameters = new DynamicParameters();
        dynamicParameters.Add("Header", comment.Header);
        dynamicParameters.Add("Body", comment.Body);
        dynamicParameters.Add("PalaceId", comment.PalaceId);
        dynamicParameters.Add("UpdatedAt", DateTime.UtcNow);
        dynamicParameters.Add("Id", comment.Id);
        return await _dbConnection.QueryFirstOrDefaultAsync<Comment>(cmd, dynamicParameters);
    }
}