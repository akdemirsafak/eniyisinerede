using eniyisinerede.API.Mappers.Comments;
using eniyisinerede.API.Repository;
using eniyisinerede.API.RequestModels.Comment;
using eniyisinerede.API.ResponseModels.Comment;

namespace eniyisinerede.API.Service
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        CommentMapper _commentMapper = new CommentMapper();

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<CreatedCommentResponse> CreateAsync(CreateCommentRequest commentRequest)
        {
            var comment= _commentMapper.CreateCommentRequestToComment(commentRequest);
            var createdComment = await _commentRepository.CreateAsync(comment);
            return _commentMapper.CommentToCreatedCommentResponse(createdComment);

        }

        public async Task DeleteAsync(int id)
        {
            var result = await _commentRepository.DeleteAsync(id);
            if (result == 0)
            {
                throw new Exception("Comment not found");
            }
        }

        public async Task<List<CommentResponse>> GetAllAsync()
        {
            var comments= await _commentRepository.GetAllAsync();
            return _commentMapper.CommentsToCommentListResponse(comments);
        }

        public async Task<CommentResponse> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment is null)
                throw new Exception("Comment not found");
            return _commentMapper.CommentToCommentResponse(comment);
        }

        public async Task<UpdatedCommentResponse> UpdateAsync(int id, UpdateCommentRequest commentRequest)
        {
            var comment= _commentMapper.UpdateCommentRequestToComment(commentRequest);
            comment.Id = id;
            var updatedComment = await _commentRepository.UpdateAsync(comment);
            return _commentMapper.CommentToUpdatedCommentResponse(updatedComment);
        }
    }
}
