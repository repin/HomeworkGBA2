using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.Models;
using MetricsAgent.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace MetricsAgentTests
{


    public class HddMetricsControllerTests
    {
        private HddMetricsController _HddMetricsController;
        private Mock<IHddMetricsRepository> _mockRepository;
        private Mock<ILogger<HddMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public HddMetricsControllerTests()
        {
            _mockRepository = new Mock<IHddMetricsRepository>();
            _mockLogger = new Mock<ILogger<HddMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _HddMetricsController = new HddMetricsController(_mockRepository.Object, _mockLogger.Object, _mockMapper.Object);
        }


        [Fact]
        public void GetHddMetrics_ReturnOk()
        {
            _mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(new List<HddMetric>());
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _HddMetricsController.GetHddMetrics(fromTime, toTime);
            _mockRepository.Verify(repository =>
                repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()));
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mockRepository.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();
            var result = _HddMetricsController.Create(new MetricsAgent.Models.Requests.HddMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });
            _mockRepository.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }
    }
}
