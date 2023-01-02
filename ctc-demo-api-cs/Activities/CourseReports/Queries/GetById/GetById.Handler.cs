using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.CourseReports.Services;

namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetById;

public class Handler : IRequestHandler<Query, SingleResponse<Response>>
{
    private readonly MongoDbClient _mongoClient;
    private readonly IMapper _mapper;

    public Handler(MongoDbClient mongoClient,IMapper mapper)
    {
        _mongoClient = mongoClient;
        _mapper = mapper;
    }

    public async Task<SingleResponse<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        var perfObjective = await _mongoClient.FindByIdAsync(request.ID);
        
        
        return new SingleResponse<Response>(_mapper.Map<Response>(perfObjective));
    }
}
