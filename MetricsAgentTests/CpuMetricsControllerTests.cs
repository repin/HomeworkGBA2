using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.Models;
using MetricsAgent.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace MetricsAgentTests
{


    public class CpuMetricsControllerTests
    {
        private CpuMetricsController _cpuMetricsController;
        private Mock<ICpuMetricsRepository> _mockRepository;
        private Mock<ILogger<CpuMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public CpuMetricsControllerTests()
        {
            _mockRepository = new Mock<ICpuMetricsRepository>();
            _mockLogger =  new Mock<ILogger<CpuMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _cpuMetricsController = new CpuMetricsController(_mockRepository.Object,_mockLogger.Object,_mockMapper.Object);
        } 


        [Fact]  
        public void GetCpuMetrics_ReturnOk()
        {
            _mockRepository.Setup(repository => repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(new List<CpuMetric>());
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _cpuMetricsController.GetCpuMetrics(fromTime, toTime);
            _mockRepository.Verify(repository =>
                repository.GetByTimePeriod(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>()));
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mockRepository.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            var result = _cpuMetricsController.Create(new MetricsAgent.Models.Requests.CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });
            _mockRepository.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }
}
