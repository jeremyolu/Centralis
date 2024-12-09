using Centralis.Core.Interfaces;
using Centralis.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Centralis.API.Controllers
{
    [Route("api/data")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("hospitals")]
        public async Task<IActionResult> Get()
        {
            var response = await _dataService.GetHospitals();

            return Ok(response);
        }

        [HttpGet("hospitals/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var response = await _dataService.GetHospital(id);

            if (response == null)
            {
                return NotFound(new { message = $"Hospital with ID {id} not found.", errorCode = 404 });
            }

            return Ok(response);
        }
    }
}
