using AutoMapper;
using SporSalonuYonetim.Core.DTOs;
using SporSalonuYonetim.Core.Entities;

namespace SporSalonuYonetim.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
            CreateMap<UserUpdateDto, User>();
            CreateMap<Trainer, TrainerDto>().ReverseMap();
            CreateMap<TrainerCreateDto, Trainer>();
            CreateMap<TrainerUpdateDto, Trainer>();

            
            CreateMap<SubscriptionType, SubscriptionTypeDto>().ReverseMap();
            CreateMap<SubscriptionTypeCreateDto, SubscriptionType>();

        
            CreateMap<WorkoutProgram, WorkoutProgramDto>().ReverseMap();
            CreateMap<WorkoutProgramCreateDto, WorkoutProgram>();
        }
    }
}
