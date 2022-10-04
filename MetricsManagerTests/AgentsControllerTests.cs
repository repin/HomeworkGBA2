using AutoMapper;
using MetricsManager.Controllers;
using MetricsManager.Models;
using MetricsManager.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Priority;

namespace MetricsManagerTests
{
    public class AgentsControllerTests
    {
        private AgentsController _agentsController;
        private Mock<IAgentRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;

        public AgentsControllerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IAgentRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public void GetAgentsTest()
        {
            ActionResult<AgentInfo[]> actionResult = _agentsController.GetAllAgents();
            //ActionResult<AgentInfo[]> result = Assert.IsAssignableFrom<ActionResult<AgentInfo[]>>(actionResult);
            Assert.NotNull(((OkObjectResult)actionResult.Result).Value);
        }

    }
}
