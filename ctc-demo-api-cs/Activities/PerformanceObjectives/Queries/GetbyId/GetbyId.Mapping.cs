using AutoMapper;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Queries.GetbyId;

public class Mapping: Profile
{
    public Mapping()
    {
        // TODO: Add Mapping
        CreateMap<Model, Response>(MemberList.None);
    }
}
