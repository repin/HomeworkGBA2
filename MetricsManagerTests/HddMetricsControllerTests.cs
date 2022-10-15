﻿using MetricsManager.Controllers;
using MetricsManager.Services.Client;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MetricsManagerTests
{
    public class HddMetricsControllerTests
    {
        private HddMetricsController _hddMetricsController;
        private Mock<IMetricsAgentClient> _metricsAgentClient;
        private Mock<IHttpClientFactory> _httpClientFactory;

        public HddMetricsControllerTests()
        {
            _metricsAgentClient = new Mock<IMetricsAgentClient>();
            _httpClientFactory = new Mock<IHttpClientFactory>();
            _hddMetricsController = new HddMetricsController(_metricsAgentClient.Object, _httpClientFactory.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnOk()
        {
            int agentId = 1;
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);

            var result = _hddMetricsController.GetMetricsFromAgent(agentId, fromTime,
            toTime);

            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsAll_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);

            var result = _hddMetricsController.GetMetricsFromAll(fromTime, toTime);

            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
