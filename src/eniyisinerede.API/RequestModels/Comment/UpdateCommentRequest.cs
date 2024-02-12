namespace eniyisinerede.API.RequestModels.Comment;
public record UpdateCommentRequest(string Header,
    string? Body,
    int PalaceId);