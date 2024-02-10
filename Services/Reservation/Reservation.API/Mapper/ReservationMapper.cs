using Reservation.API.RequestModels;
using Reservation.API.ResponseModels;
using Riok.Mapperly.Abstractions;

namespace Reservation.API.Mapper;
[Mapper]
public partial class ReservationMapper
{
    //CreateRequest mapping
    [MapProperty(nameof(CreateReservationRequest.NumberOfPerson), nameof(Entity.Reservation.NumberOfPerson))]
    public partial Entity.Reservation CreateReservationRequestToReservation(CreateReservationRequest createReservationRequest);

    //CreateResponse mapping
    [MapProperty(nameof(CreatedReservationResponse.Status), nameof(Entity.Reservation.Status))]
    [MapEnumValue(nameof(CreatedReservationResponse.StatusId), nameof(Entity.Reservation.Status))]
    public partial CreatedReservationResponse ReservationToCreatedReservationResponse(Entity.Reservation reservation);

    //Update Response Mapping
    [MapProperty(nameof(UpdatedReservationResponse.Status), nameof(Entity.Reservation.Status))]
    [MapEnumValue(nameof(UpdatedReservationResponse.StatusId), nameof(Entity.Reservation.Status))]
    public partial UpdatedReservationResponse ReservationToUpdatedReservationResponse(Entity.Reservation reservation);


    //Get Single Mapping
    [MapEnumValue(nameof(ReservationResponse.StatusId), nameof(Entity.Reservation.Status))]
    [MapProperty(nameof(ReservationResponse.Status), nameof(Entity.Reservation.Status))]
    public partial ReservationResponse ReservationToReservationResponse(Entity.Reservation reservation);


    //GetAll Mapping
    [MapEnumValue(nameof(ReservationResponse.StatusId), nameof(Entity.Reservation.Status))]
    [MapProperty(nameof(ReservationResponse.Status), nameof(Entity.Reservation.Status))]
    public partial List<ReservationResponse> ReservationsToReservationListResponse(List<Entity.Reservation> reservations);
}
