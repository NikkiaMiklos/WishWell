using Microsoft.AspNetCore.Mvc;


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

        private class ToSendBack
        {
            public string? Name { get; set; }
            public string? Token { get; set; }
            public int? Id { get; set; }

        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] UserLogin user)
        {

            WebTokenUtility webTokenUtility = new WebTokenUtility();
            try {
                User? login=null;
                if (string.IsNullOrEmpty(user.Password)==false && string.IsNullOrEmpty(user.Email)==false) {
                    login = excelSessionHelper.Login(user.Email, user.Password);
                }

                if (login?.ID!=null ) {
                    var token = webTokenUtility.GenerateToken(Convert.ToInt32(login.ID));
                    var toSendBack = new ToSendBack() { 
                        Name=login.Name,
                        Id=login.ID,
                        Token=token
                    };
                    return Ok(toSendBack);
                }
                return StatusCode(500, "Unauthorized");

            } catch(Exception ex) {
                return StatusCode(500, "Unauthorized");
            }
        }
    }
}
