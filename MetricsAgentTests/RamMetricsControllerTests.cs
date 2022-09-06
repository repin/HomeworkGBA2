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

    public class RamMetricsControllerTests
    {
        private RamMetricsController _ramMetricsController;

        public RamMetricsControllerTests()
        {
            _ramMetricsController = new RamMetricsController();
        }

        [Fact]
        public void GetCpuMetrics_ReturnOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);
            var result = _ramMetricsController.GetRamMetrics(fromTime, toTime);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
