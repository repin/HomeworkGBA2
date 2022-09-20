using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.Models;
using MetricsAgent.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace MetricsAgentTests
{


    public class NetworkMetricsControllerTests
    {
        private NetworkMetricsController _NetworkMetricsController;
        private Mock<INetworkMetricsRepository> _mockRepository;
        private Mock<ILogger<NetworkMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public NetworkMetricsControllerTests()
        {
            _mockRepository = new Mock<INetworkMetricsRepository>();
            _mockLogger = new Mock<ILogger<NetworkMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _NetworkMetricsController = new NetworkMetricsController(_mockRepository.Object, _mockLogger.Object, _mockMapper.Object);
        }


        [Fact]
        public void GetNetworkMetrics_ReturnOk()
        {
            _mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(new List<NetworkMetric>());
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _NetworkMetricsController.GetNetworkMetrics(fromTime, toTime);
            _mockRepository.Verify(repository =>
                repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()));
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mockRepository.Setup(repository => repository.Create(It.IsAny<NetworkMetric>())).Verifiable();
            var result = _NetworkMetricsController.Create(new MetricsAgent.Models.Requests.NetworkMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });
            _mockRepository.Verify(repository => repository.Create(It.IsAny<NetworkMetric>()), Times.AtMostOnce());
        }
    }
}
