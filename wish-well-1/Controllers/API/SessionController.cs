using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using wish_well_1.Controllers.Excel;

namespace wish_well_1.Controllers
{
    [ApiController]
    [Route("session")]

    public class SessionController : ControllerBase
    {
        private SessionCsvController excelSessionHelper = new SessionCsvController();

        private readonly ILogger<SessionController> _logger;

        public SessionController(ILogger<SessionController> logger) {
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] UserLogin user)
        {
  
            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Email)) {
                return StatusCode(500, "Must be a valid user with email and password.");
            } else { 
                return Ok(excelSessionHelper.Login(user.Email, user.Password));
            }
        }
    }
}
