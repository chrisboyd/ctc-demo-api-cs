using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.PerformanceObjectives.Services;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Commands.UpdateById;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IPerfObjectiveRepository _repository;
    private readonly IMapper _mapper;

    public Handler(IPerfObjectiveRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        await _repository.UpdateByIdAsync(request.Id, request.UpdateEvalObjDto);
        return new SingleResponse<Response>(_mapper.Map<Response>(request.UpdateEvalObjDto));
    }
}
