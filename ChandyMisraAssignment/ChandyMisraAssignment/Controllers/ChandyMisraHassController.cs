using System.Net;
using ChandyMisraAssignment.Extension;
using Microsoft.AspNetCore.Mvc;

namespace ChandyMisraAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChandyMisraHassController : ControllerBase
    {
        private readonly ILogger<ChandyMisraHassController> _logger;

        public ChandyMisraHassController(ILogger<ChandyMisraHassController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult DetectDeadlock([FromBody] DeadlockDetectionInput input)
        {
            ChandyMisraHaas cmh = new ChandyMisraHaas(input.Graph, input.NumProcesses);

            bool isDeadlocked = cmh.IsDeadlocked();

            if (isDeadlocked)
            {
                return Ok("Deadlock detected");
            }
            else
            {
                return Ok("Deadlock not detected");
            }
        }
    }
}