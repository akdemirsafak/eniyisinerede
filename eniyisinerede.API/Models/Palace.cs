namespace eniyisinerede.API.Models;

public class Palace:BaseModel
{
    public string Name { get; set; }
    public IList<Comment> Comments { get; set; }
    public District County { get; set; }
}
