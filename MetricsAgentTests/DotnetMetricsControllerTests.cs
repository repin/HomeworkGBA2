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

    public class DotnetMetricsControllerTests
    {
        private DotnetMetricsController _dotnetMetricsController;
        private Mock<IDotnetMetricsRepository> _mock;
        private Mock<ILogger<DotnetMetricsController>> _logger;


        public DotnetMetricsControllerTests()
        {
            _mock = new Mock<IDotnetMetricsRepository>();
            _logger = new Mock<ILogger<DotnetMetricsController>>();

            _dotnetMetricsController = new DotnetMetricsController(_mock.Object, _logger.Object);
        }


        [Fact]
        public void GetDotnetMetrics_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _dotnetMetricsController.GetDotnetMetrics(fromTime, toTime);
            Assert.IsAssignableFrom<ActionResult<IList<DotnetMetric>>>(result);
        }
        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<DotnetMetric>())).Verifiable();
            var result = _dotnetMetricsController.Create(new MetricsAgent.Models.Requests.DotnetMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });
            _mock.Verify(repository => repository.Create(It.IsAny<DotnetMetric>()), Times.AtMostOnce());
        }

    }
}
