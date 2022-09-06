using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsAgentTests
{
    // TODO: Домашнее задание [Пункт 3]
    //  Добавьте проект с тестами для агента сбора метрик. Напишите простые Unit-тесты на каждый
    // метод отдельно взятого контроллера в обоих тестовых проектах.

    public class DotnetMetricsControllerTests
    {
        private DotnetMerticsController _dotnetMetricsController;

        public DotnetMetricsControllerTests()
        {
            _dotnetMetricsController = new DotnetMerticsController();
        }

        [Fact]
        public void GetCpuMetrics_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _dotnetMetricsController.GetDotnetMetrics(fromTime, toTime);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
