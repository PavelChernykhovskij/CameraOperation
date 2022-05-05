using AutoMapper;
using CamerOperationClassLibrary.Dtos;
using CamerOperationClassLibrary.Models;

namespace CamerOperationClassLibrary
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Fixation, FixationDto>().ReverseMap();
            CreateMap<RuleOfSearchBySpeed, RuleOfSearchBySpeedDto>().ReverseMap();
            CreateMap<RuleOfSearchByNumber, RuleOfSearchByNumberDto>().ReverseMap();
            CreateMap<TriggeringBySpeed, TriggeringBySpeedDto>()
                .ForMember(dest => dest.Rule, opt => opt.MapFrom(src => src.RuleOfSearchBySpeed.Speed));
            CreateMap<TriggeringByNumber, TriggeringByNumberDto>()
                .ForMember(dest => dest.Rule, opt => opt.MapFrom(src => src.RuleOfSearchByNumber.Number));
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
