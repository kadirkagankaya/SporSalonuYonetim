using AutoMapper;
using SporSalonuYonetim.Core.DTOs;
using SporSalonuYonetim.Core.Entities;

namespace SporSalonuYonetim.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // User Mapping
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            // Trainer Mapping
            CreateMap<Trainer, TrainerDto>().ReverseMap();
            CreateMap<TrainerCreateDto, Trainer>();
            CreateMap<TrainerUpdateDto, Trainer>();

            // SubscriptionType Mapping (DTO'su yoksa direkt entity veya boş bir map)
            // Bu örnekte SubscriptionType için ayrı DTO açmadık ama gerekirse ekleriz.
        }
    }
}
