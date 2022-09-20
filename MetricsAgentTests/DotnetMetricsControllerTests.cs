using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.Models;
using MetricsAgent.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace MetricsAgentTests
{


    public class DotnetMetricsControllerTests
    {
        private DotnetMetricsController _DotnetMetricsController;
        private Mock<IDotnetMetricsRepository> _mockRepository;
        private Mock<ILogger<DotnetMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public DotnetMetricsControllerTests()
        {
            _mockRepository = new Mock<IDotnetMetricsRepository>();
            _mockLogger = new Mock<ILogger<DotnetMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _DotnetMetricsController = new DotnetMetricsController(_mockRepository.Object, _mockLogger.Object, _mockMapper.Object);
        }


        [Fact]
        public void GetDotnetMetrics_ReturnOk()
        {
            _mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(new List<DotnetMetric>());
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _DotnetMetricsController.GetDotnetMetrics(fromTime, toTime);
            _mockRepository.Verify(repository =>
                repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()));
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mockRepository.Setup(repository => repository.Create(It.IsAny<DotnetMetric>())).Verifiable();
            var result = _DotnetMetricsController.Create(new MetricsAgent.Models.Requests.DotnetMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });
            _mockRepository.Verify(repository => repository.Create(It.IsAny<DotnetMetric>()), Times.AtMostOnce());
        }
    }
}
