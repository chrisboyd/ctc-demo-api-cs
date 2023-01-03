using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Threenine.ApiResponse;
using Threenine.Data;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Queries.GetbyId;

public class Handler : IRequestHandler<Query, SingleResponse<Response>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Handler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SingleResponse<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.GetReadOnlyRepositoryAsync<Model>()
            .SingleOrDefaultAsync(predicate: x => x.Id == request.Id);
        
        return new SingleResponse<Response>(_mapper.Map<Response>(result));
    }
}
