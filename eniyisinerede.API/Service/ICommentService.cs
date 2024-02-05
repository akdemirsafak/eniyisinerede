using eniyisinerede.API.RequestModels.Comment;
using eniyisinerede.API.ResponseModels.Comment;

namespace eniyisinerede.API.Service
{
    public interface ICommentService
    {
        Task<List<CommentResponse>> GetAllAsync();
        Task<CommentResponse> GetByIdAsync(int id);
        Task<CreatedCommentResponse> CreateAsync(CreateCommentRequest commentRequest);
        Task<UpdatedCommentResponse> UpdateAsync(int id, UpdateCommentRequest commentRequest);
        Task DeleteAsync(int id);
    }
}
