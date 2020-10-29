using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;
using EdFi.Ods.Common.Configuration;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Models.Queries;
using EdFi.Ods.Features.Publishing.Repositories;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Features.Publishing.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Authorize]
    [Route("data/v3/publishing/snapshots")]
    public class SnapshotsController : ControllerBase
    {
        private readonly IGetSnapshots _getSnapshots;
        private readonly ILog _logger = LogManager.GetLogger(typeof(SnapshotsController));
        private readonly bool _isEnabled;

        // Until controllers are loaded from the container, the optional dependency is necessary
        // to be able to return a 404 Not Found instead of a 500 Internal Server Error if the route
        // is requested by the API client when the feature is disabled.
        public SnapshotsController(ApiSettings apiSettings, IGetSnapshots getSnapshots = null)
        {
            _getSnapshots = getSnapshots;
            _isEnabled = apiSettings.IsFeatureEnabled(ApiFeature.Publishing.GetConfigKeyName());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UrlQueryParametersRequest urlQueryParametersRequest)
        {
            if (!_isEnabled)
            {
                _logger.Debug($"{nameof(SnapshotsController)} was matched to handle the request, but the '{ApiFeature.Publishing}' feature is disabled.");

                // Not Found
                return new ObjectResult(null)
                {
                    StatusCode = (int) HttpStatusCode.NotFound,
                };
            }

            var snapshots = await _getSnapshots.GetAllAsync(new QueryParameters(urlQueryParametersRequest));
            return Ok(snapshots);
        }
    }
}
