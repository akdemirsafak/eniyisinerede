namespace eniyisinerede.API.Models
{
    public class Comment : BaseModel
    {
        public int UserId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public int PalaceId { get; set; }
    }
}
