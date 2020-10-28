using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Features.Publishing.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Features.Publishing.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("publishing/snapshots")]
    public class SnapshotsController : ControllerBase
    {
        private readonly IGetSnapshots _getSnapshots;

        public SnapshotsController(IGetSnapshots getSnapshots)
        {
            _getSnapshots = getSnapshots;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UrlQueryParametersRequest urlQueryParametersRequest)
        {
            var snapshots = await _getSnapshots.GetAllAsync(new QueryParameters(urlQueryParametersRequest));
            return Ok(snapshots);
        }

        // NOTE: The SnapshotContextActionFilter should prevent these methods from executing,
        // but they are overridden here to ensure that no data modification can happen.
        // public async Task<IActionResult> Post() 
        //     => await Task.FromResult(new SnapshotsAreReadOnlyResult());
        //
        // public async Task<IActionResult> Put([FromRoute] Guid id) 
        //     => await Task.FromResult(new SnapshotsAreReadOnlyResult());
        //
        // public async Task<IActionResult> Delete([FromRoute] Guid id) 
        //     => await Task.FromResult(new SnapshotsAreReadOnlyResult());
    }
}
