namespace Reservation.API.ResponseModels;

public class ReservationResponse : BaseResponse
{
    public DateTime DateAndTime { get; set; }
    public string? Notes { get; set; }
    public string PhoneNumber { get; set; }
    public string Status { get; set; }
    public int StatusId { get; set; }
    public int NumberOfPerson { get; set; }
    public Guid PlaceId { get; set; }
}
