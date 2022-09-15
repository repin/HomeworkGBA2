using MetricsAgent.Models;
using MetricsAgent.Models.Requests;
using MetricsAgent.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        #region Services

        private readonly ILogger<CpuMetricsController> _logger;
        private readonly ICpuMetricsRepository _cpuMetricsRepository;
        #endregion


        public CpuMetricsController(
            ICpuMetricsRepository cpuMetricsRepository,
            ILogger<CpuMetricsController> logger)
        {
            _cpuMetricsRepository = cpuMetricsRepository;
            _logger = logger;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            _cpuMetricsRepository.Create(new Models.CpuMetric
            {
                Value = request.Value,
                Time = (int)request.Time.TotalSeconds
            });
            _logger.LogInformation("Create cpu metrics.");

            return Ok();
        }

        /// <summary>
        /// Получить статистику по нагрузке на ЦП за период
        /// </summary>
        /// <param name="fromTime">Время начала периода</param>
        /// <param name="toTime">Время окончания периода</param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public ActionResult<IList<CpuMetric>> GetCpuMetrics(
            [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {

            _logger.LogInformation("Get cpu metrics call.");
            return Ok(_cpuMetricsRepository.GetByTimePeriod(fromTime, toTime));
        }

        // TODO: Домашнее задание [Пункт 2]
        // В проект агента сбора метрик добавьте контроллеры для сбора метрик, аналогичные
        // менеджеру сбора метрик.Добавьте методы для получения метрик с агента, доступные по
        //следующим путям
        // a. api/metrics/cpu/from/{fromTime}/to/{toTime} [ВЫПОЛНИЛИ ВМЕСТЕ]
        // b. api / metrics / dotnet / errors - count / from /{ fromTime}/ to /{ toTime}
        // c. api / metrics / network / from /{ fromTime}/ to /{ toTime}
        // d. api / metrics / hdd / left / from /{ fromTime}/ to /{ toTime}
        // e. api / metrics / ram / available / from /{ fromTime}/ to /{ toTime}


    }
}
