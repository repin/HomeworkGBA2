using MetricsAgent.Controllers;
using MetricsAgent.Models;
using MetricsAgent.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace MetricsAgentTests
{


    public class CpuMetricsControllerTests
    {
        private CpuMetricsController _cpuMetricsController;
        private Mock<ICpuMetricsRepository> _mock;
        private Mock<ILogger<CpuMetricsController>> _logger;

        public CpuMetricsControllerTests()
        {
            _mock = new Mock<ICpuMetricsRepository>();
            _logger =  new Mock<ILogger<CpuMetricsController>>();
            _cpuMetricsController = new CpuMetricsController(_mock.Object,_logger.Object);
        } 


        [Fact]  
        public void GetCpuMetrics_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _cpuMetricsController.GetCpuMetrics(fromTime, toTime);
            Assert.IsAssignableFrom<ActionResult<IList<CpuMetric>>>(result);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            var result = _cpuMetricsController.Create(new MetricsAgent.Models.Requests.CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });
            _mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }
}
