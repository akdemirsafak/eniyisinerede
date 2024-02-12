using eniyisinerede.API.Models;
using eniyisinerede.API.RequestModels.Comment;
using eniyisinerede.API.ResponseModels.Comment;
using Riok.Mapperly.Abstractions;

namespace eniyisinerede.API.Mappers.Comments;
[Mapper]
public partial class CommentMapper
{
    //Get
    public partial CommentResponse CommentToCommentResponse(Comment comment);
    public partial List<CommentResponse> CommentsToCommentListResponse(List<Comment> comments);

    //Create
    public partial Comment CreateCommentRequestToComment(CreateCommentRequest createCommentRequest);
    public partial CreatedCommentResponse CommentToCreatedCommentResponse(Comment comment);

    //Update
    public partial UpdatedCommentResponse CommentToUpdatedCommentResponse(Comment comment);
    public partial Comment UpdateCommentRequestToComment(UpdateCommentRequest updateCommentRequest);
}