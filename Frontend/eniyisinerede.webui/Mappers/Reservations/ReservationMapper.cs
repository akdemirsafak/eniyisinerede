using AutoMapper;
using eniyisinerede.webui.ViewModels.Reservations;

namespace eniyisinerede.webui.Mappers.Reservations;

public class ReservationMapper : Profile
{
    public ReservationMapper()
    {
        CreateMap<CreateReservationViewModel, ReservationViewModel>().ReverseMap();
        CreateMap<UpdateReservationViewModel, ReservationViewModel>().ReverseMap();
    }
}
