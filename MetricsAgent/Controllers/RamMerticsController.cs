﻿using MetricsAgent.Models;
using MetricsAgent.Models.Requests;
using MetricsAgent.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        #region Services

        private readonly ILogger<RamMetricsController> _logger;
        private readonly IRamMetricsRepository _ramMetricsRepository;
        #endregion


        public RamMetricsController(
            IRamMetricsRepository ramMetricsRepository,
            ILogger<RamMetricsController> logger)
        {
            _ramMetricsRepository = ramMetricsRepository;
            _logger = logger;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] RamMetricCreateRequest request)
        {
            _ramMetricsRepository.Create(new RamMetric
            {
                Value = request.Value,
                Time = (int)request.Time.TotalSeconds
            });
            _logger.LogInformation("Create ram metrics.");

            return Ok();
        }

        /// <summary>
        /// Получить статистику по нагрузке на память за период
        /// </summary>
        /// <param name="fromTime">Время начала периода</param>
        /// <param name="toTime">Время окончания периода</param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<RamMetric>> GetRamMetrics(
            [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {

            _logger.LogInformation("Get ram metrics call.");
            return Ok(_ramMetricsRepository.GetByTimePeriod(fromTime, toTime));
        }

    }
}
