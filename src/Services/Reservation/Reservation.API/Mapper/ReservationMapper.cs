using Reservation.API.RequestModels;
using Reservation.API.ResponseModels;
using Riok.Mapperly.Abstractions;

namespace Reservation.API.Mapper;
[Mapper]
public partial class ReservationMapper
{
    //CreateRequest mapping
    public partial Models.Reservation CreateReservationRequestToReservation(CreateReservationRequest createReservationRequest);

    //CreateResponse mapping
    public partial CreatedReservationResponse ReservationToCreatedReservationResponse(Models.Reservation reservation);

    //Update Response Mapping
    public partial UpdatedReservationResponse ReservationToUpdatedReservationResponse(Models.Reservation reservation);


    //Get Single Mapping
    public partial ReservationResponse ReservationToReservationResponse(Models.Reservation reservation);


    //GetAll Mapping
    [MapEnumValue(nameof(ReservationResponse.StatusId), nameof(Models.Reservation.Status))]
    public partial List<ReservationResponse> ReservationsToReservationListResponse(List<Models.Reservation> reservations);
}
