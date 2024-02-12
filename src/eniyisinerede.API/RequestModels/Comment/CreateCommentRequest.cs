namespace eniyisinerede.API.RequestModels.Comment;
public record CreateCommentRequest(string Header,
    string? Body,
    int PalaceId);