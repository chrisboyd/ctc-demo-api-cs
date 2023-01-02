using System.Collections.Generic;
using System.Threading.Tasks;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Services;

public interface IMongoDbClient
{
    Task<List<PerformanceObjective>> GetAsync();
    Task<PerformanceObjective> FindByIdAsync(string id);
}