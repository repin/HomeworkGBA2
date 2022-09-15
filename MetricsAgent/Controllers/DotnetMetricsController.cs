using MetricsAgent.Models;
using MetricsAgent.Models.Requests;
using MetricsAgent.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotnetMetricsController : ControllerBase
    {
        #region Services

        private readonly ILogger<DotnetMetricsController> _logger;
        private readonly IDotnetMetricsRepository _dotnetMetricsRepository;
        #endregion


        public DotnetMetricsController(
            IDotnetMetricsRepository dotnetMetricsRepository,
            ILogger<DotnetMetricsController> logger)
        {
            _dotnetMetricsRepository = dotnetMetricsRepository;
            _logger = logger;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotnetMetricCreateRequest request)
        {
            _dotnetMetricsRepository.Create(new Models.DotnetMetric
            {
                Value = request.Value,
                Time = (int)request.Time.TotalSeconds
            });
            _logger.LogInformation("Create dotnet metrics.");

            return Ok();
        }

        /// <summary>
        /// Получить статистику по количеству ошибок DotNet за период
        /// </summary>
        /// <param name="fromTime">Время начала периода</param>
        /// <param name="toTime">Время окончания периода</param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<DotnetMetric>> GetDotnetMetrics(
            [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {

            _logger.LogInformation("Get dotnet metrics call.");
            return Ok(_dotnetMetricsRepository.GetByTimePeriod(fromTime, toTime));
        }


    }
}
