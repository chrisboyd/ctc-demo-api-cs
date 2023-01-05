using System.Threading.Tasks;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Services;

public interface ICourseReportRepository
{
    Task<CourseReport> FindByIdAsync(int id);
}