using eniyisinerede.API.Models;

namespace eniyisinerede.API.Repository;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
    Task<Comment> GetByIdAsync(int id);
    Task<Comment> CreateAsync(Comment comment);
    Task<Comment> UpdateAsync(Comment comment);
    Task<int> DeleteAsync(int id);
}
