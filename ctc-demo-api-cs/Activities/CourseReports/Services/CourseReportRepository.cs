using System.Threading.Tasks;
using WYWM.CTC.API.Activities.CourseReports.Domain;
using WYWM.CTC.API.Activities.CourseReports.Infrastructure;
using WYWM.CTC.API.Exceptions;

namespace WYWM.CTC.API.Activities.CourseReports.Services;

public class CourseReportRepository : ICourseReportRepository
{
    private readonly CourseReportContext _context;

    public CourseReportRepository(CourseReportContext context)
    {
        _context = context;
    }
    public async Task<CourseReport> FindByIdAsync(int id)
    {
        var result = await _context.CourseReports.
            FindAsync(id);
        
        if (result is null)
        {
            throw new NotFoundException("Not Found",
                $"Course Report with id: {id} was not found");
        }
        
        return result;
    }
}