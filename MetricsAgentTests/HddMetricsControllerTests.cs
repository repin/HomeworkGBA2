using MetricsAgent.Controllers;
using MetricsAgent.Models;
using MetricsAgent.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace MetricsAgentTests
{
    // TODO: Домашнее задание [Пункт 3]
    //  Добавьте проект с тестами для агента сбора метрик. Напишите простые Unit-тесты на каждый
    // метод отдельно взятого контроллера в обоих тестовых проектах.

    public class HddMetricsControllerTests
    {
        private HddMetricsController _hddMetricsController;
        private Mock<IHddMetricsRepository> _mock;
        private Mock<ILogger<HddMetricsController>> _logger;


        public HddMetricsControllerTests()
        {
            _mock = new Mock<IHddMetricsRepository>();
            _logger = new Mock<ILogger<HddMetricsController>>();
            _hddMetricsController = new HddMetricsController(_mock.Object, _logger.Object);
        }

        [Fact]
        public void GetHddMetrics_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _hddMetricsController.GetHddMetrics(fromTime, toTime);
            Assert.IsAssignableFrom<ActionResult<IList<HddMetric>>>(result);
        }
        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();
            var result = _hddMetricsController.Create(new MetricsAgent.Models.Requests.HddMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });
            _mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }

    }
}
