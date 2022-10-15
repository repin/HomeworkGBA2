using AutoMapper;
using MetricsManager.Models;
using MetricsManager.Models.Dto;
using MetricsManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {

        #region Services

        private readonly IAgentRepository _agentRepository;
        private readonly IMapper _mapper;


        #endregion

        #region Constuctors

        public AgentsController(IAgentRepository agentRepository, IMapper mapper)
        {
            _agentRepository = agentRepository;
            _mapper = mapper;
        }

        #endregion

        #region Public Methods

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfoDto request)
        {

            _agentRepository.Create(_mapper.Map<AgentInfo>(request));
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            _agentRepository.EnableAgentById(agentId);
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _agentRepository.DisableAgentById(agentId);
            return Ok();
        }


        [HttpGet("getAll")]
        public ActionResult<AgentInfo[]> GetAllAgents()
        {
            return Ok(_agentRepository.GetAll());
        }

        [HttpDelete("delete/{agentId}")]
        public IActionResult Delete([FromRoute] int agentId)
        {
            _agentRepository.Delete(agentId);
            return Ok();
        }


        #endregion

    }
}
