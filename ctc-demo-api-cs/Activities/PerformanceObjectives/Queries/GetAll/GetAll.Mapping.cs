using AutoMapper;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Queries.GetAll;

public class Mapping: Profile
{
    public Mapping()
    {
       // TODO:  Complete Mapping
       CreateMap<Model, Domain>(MemberList.None)
           
           ;
    }
}
