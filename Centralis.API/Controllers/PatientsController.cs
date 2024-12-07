using Centralis.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Centralis.API.Controllers
{
    [ApiController]
    [Route("patients")]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> _logger;
        private readonly IPatientService _patientService;

        public PatientsController(ILogger<PatientsController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _patientService.GetPatients();
            return Ok(response);
        }
    }
}
