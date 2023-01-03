using AutoMapper;

namespace  WYWM.CTC.API.Activities.PerformanceObjectives.Commands.Put;

public class Mapping: Profile
{
    public Mapping()
    {
        CreateMap<Domain, Model>(MemberList.None)
            // TODO: Implement Mapping here
          ;

        CreateMap<Model, Response>(MemberList.None)
            .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id));
    }
}
