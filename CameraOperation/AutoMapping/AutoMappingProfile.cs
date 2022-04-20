using AutoMapper;
using CamerOperationClassLibrary.Models;
using CamerOperationClassLibrary.AutoMapping.DtoModels;


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
