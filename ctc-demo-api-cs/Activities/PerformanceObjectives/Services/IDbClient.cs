using System.Collections.Generic;
using System.Threading.Tasks;
using WYWM.CTC.API.Activities.PerformanceObjectives.Domain;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Services;

public interface IDbClient
{
    Task<List<PerformanceObjective>> GetAsync();
    Task<PerformanceObjective> FindByIdAsync(string id);
    Task<bool> UpdateByIdAsync(string id, UpdateEvalObjDto updateEvalObjDto);
}