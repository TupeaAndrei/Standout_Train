using AutoMapper;
using Standout_Train.DAL.Models;
using Standout_Train.TL.DTOs;

namespace Standout_Train.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Achievments, AchievmentsDTO>().ReverseMap();
            CreateMap<County,CountyDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Society, SocietyDTO>().ReverseMap();
            CreateMap<Station, StationDTO>().ReverseMap();
            CreateMap<Ticket, TicketDTO>().ReverseMap();
            CreateMap<Train, TrainDTO>().ReverseMap();
            CreateMap<TrainStation, TrainStationDTO>().ReverseMap();
        }
    }
}
