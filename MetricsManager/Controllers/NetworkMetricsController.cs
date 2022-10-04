using MetricsManager.Models.Requests;
using MetricsManager.Services.Client;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [Route("api/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {

        #region Services

        private IHttpClientFactory _httpClientFactory;
        private IMetricsAgentClient _metricsAgentClient;

        #endregion


        public NetworkMetricsController(
            IMetricsAgentClient metricsAgentClient,
            IHttpClientFactory httpClientFactory
            )
        {
            _httpClientFactory = httpClientFactory;
            _metricsAgentClient = metricsAgentClient;
        }

        [HttpGet("agent-by-id")]
        public ActionResult<NetworkMetricsResponse> GetMetricsFromAgent(
            [FromQuery] int agentId, [FromQuery] TimeSpan fromTime, [FromQuery] TimeSpan toTime)
        {
            return Ok(_metricsAgentClient.GetNetworkMetrics(new NetworkMetricsRequest
            {
                AgentId = agentId,
                FromTime = fromTime,
                ToTime = toTime
            }));
        }


        [HttpGet("get-all")]
        public IActionResult GetMetricsFromAll(
            [FromQuery] TimeSpan fromTime, [FromQuery] TimeSpan toTime)
        {
            return Ok();
        }
    }
}
