using Microsoft.AspNetCore.Mvc;
using wish_well_1.Controllers.Excel;

namespace wish_well_1.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult Post()
        {
            ExampleCsvControllerUse.TestUser();
            ExampleCsvControllerUse.TestProduct();
            var email = "email";
            var password = "password";
            
            return Ok(excelSessionHelper.Login(email, password));
        }


    }
}
