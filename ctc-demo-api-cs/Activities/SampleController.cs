using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WYWM.CTC.API.Activities.CourseReports.Domain;
using WYWM.CTC.API.Activities.CourseReports.Services;

namespace WYWM.CTC.API.Activities;

[Route(Routes.Sample)]
public class SampleController : ControllerBase
{
    readonly MongoDbClient _mongoDbClient;

    public SampleController(MongoDbClient mongoDbClient)
    {
        _mongoDbClient = mongoDbClient;
    }

    [HttpGet]
    public async Task<List<PerformanceObjective>> Get()
    {
        return await _mongoDbClient.GetAsync();
    }
}