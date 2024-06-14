using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using wish_well_1.Controllers.Excel;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace wish_well_1.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private ExcelSessionHelper excelSessionHelper = new ExcelSessionHelper();

        // POST api/<Session>
        [HttpPost("/login")]
        public bool Post([FromBody] string email, [FromBody] string password) {

            return excelSessionHelper.Login(email, password);
        }

    }
}
