using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Threenine.ApiResponse;
using Threenine.Data;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Queries.GetAll;

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
        var results = await _unitOfWork.GetReadOnlyRepositoryAsync<Model>()
            .GetListAsync( size: Int32.MaxValue);
        
        return new SingleResponse<Response>(new Response { Domains = _mapper.Map<List<Domain>>(results.Items)});
    }
}
