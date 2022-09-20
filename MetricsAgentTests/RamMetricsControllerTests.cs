using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.Models;
using MetricsAgent.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace MetricsAgentTests
{


    public class RamMetricsControllerTests
    {
        private RamMetricsController _RamMetricsController;
        private Mock<IRamMetricsRepository> _mockRepository;
        private Mock<ILogger<RamMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public RamMetricsControllerTests()
        {
            _mockRepository = new Mock<IRamMetricsRepository>();
            _mockLogger =  new Mock<ILogger<RamMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _RamMetricsController = new RamMetricsController(_mockRepository.Object,_mockLogger.Object,_mockMapper.Object);
        } 


        [Fact]  
        public void GetRamMetrics_ReturnOk()
        {
            _mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(new List<RamMetric>());
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _RamMetricsController.GetRamMetrics(fromTime, toTime);
            _mockRepository.Verify(repository =>
                repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()));
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mockRepository.Setup(repository => repository.Create(It.IsAny<RamMetric>())).Verifiable();
            var result = _RamMetricsController.Create(new MetricsAgent.Models.Requests.RamMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });
            _mockRepository.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }
    }
}
