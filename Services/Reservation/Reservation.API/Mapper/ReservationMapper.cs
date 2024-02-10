using AutoMapper;
using Reservation.API.Entity;
using Reservation.API.RequestModels;
using Reservation.API.ResponseModels;

namespace Reservation.API.Mapper
{
    public class ReservationMapper:Profile
    {
        public ReservationMapper()
        {
            CreateMap<CreateReservationRequest, Entity.Reservation>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(src => System.DateTime.UtcNow))
                .ForMember(x => x.Status, opt => opt.MapFrom(src => ReservationStatus.Pending));
            
            CreateMap<UpdateReservationRequest, Entity.Reservation>()
                .ForMember(x => x.UpdatedAt, opt => opt.MapFrom(src => System.DateTime.UtcNow));

            CreateMap<Entity.Reservation,CreatedReservationResponse > ()
                .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(x => x.StatusId, opt => opt.MapFrom(src => (int)src.Status))
                .ReverseMap();
            CreateMap<UpdatedReservationResponse, Entity.Reservation>().ReverseMap();

            CreateMap<Entity.Reservation, ReservationResponse>()
                .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(x => x.StatusId, opt => opt.MapFrom(src => (int)src.Status))
                .ReverseMap();
        }
    }
}
