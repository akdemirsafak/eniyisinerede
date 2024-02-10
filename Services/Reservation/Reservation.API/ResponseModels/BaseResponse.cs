namespace Reservation.API.ResponseModels;

public class BaseResponse
{
    public Guid Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public Guid? CreatedById { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public Guid? UpdatedById { get; set; }
}
