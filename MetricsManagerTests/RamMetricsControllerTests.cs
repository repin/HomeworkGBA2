﻿using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerTests
{
    public class RamMetricsControllerTests
    {
        private RamMetricsController _ramMetricsController;
        private Mock<ILogger<RamMetricsController>> _logger;


        public RamMetricsControllerTests()
        {
            _logger = new Mock<ILogger<RamMetricsController>>();
            _ramMetricsController = new RamMetricsController(_logger.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnOk()
        {
            int agentId = 1;
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);

            var result = _ramMetricsController.GetMetricsFromAgent(agentId, fromTime,
            toTime);

            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsAll_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);

            var result = _ramMetricsController.GetMetricsFromAll( fromTime, toTime);

            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
