using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.CourseReports.Services;

namespace WYWM.CTC.API.Activities.CourseReports.Commands.SaveCourseReport;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly ICourseReportRepository _repository;
    private readonly IMapper _mapper;

    public Handler(ICourseReportRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var savedCourseReport = await _repository.SaveAsync(request.SaveCourseReportDto);
        return new SingleResponse<Response>(_mapper.Map<Response>(savedCourseReport));
    }
}
