using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.CourseReports.Services;


namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetInstructorReports;

public class Handler : IRequestHandler<Query, ListResponse<Response>>
{
    private readonly ICourseReportRepository _repository;
    private readonly IMapper _mapper;

    public Handler(ICourseReportRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ListResponse<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        var courseReports = await _repository.FindByInstructorAsync(request.InstructorEmail);
        return new ListResponse<Response>(_mapper.Map<List<Response>>(courseReports));
    }
}
