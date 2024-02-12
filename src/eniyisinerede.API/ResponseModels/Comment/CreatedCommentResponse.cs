namespace eniyisinerede.API.ResponseModels.Comment;
public class CreatedCommentResponse : BaseResponseModel
{
    public string Header { get; set; }
    public string Body { get; set; }
    public int PalaceId { get; set; }
}