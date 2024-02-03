namespace eniyisinerede.API.Models
{
    public class Comment:BaseModel
    {
        public Guid UserId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
    }
}
