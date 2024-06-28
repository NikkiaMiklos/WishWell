using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wish_well_1.Controllers.Csv;

namespace wish_well_1.Controllers.API
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private UserCsvController _UserCsvController = new UserCsvController();

        // POST: UserController/Create
        [HttpPost("create")]
        public IActionResult Post([FromBody] CreateUser user)
        {
            string name = string.IsNullOrEmpty(user.Name) ? "" : user.Name;
            string email = string.IsNullOrEmpty(user.Email) ? "" : user.Email;
            string pass = string.IsNullOrEmpty(user.Password) ? "": user.Password;
            return Ok(_UserCsvController.UserAdd(name, email, pass));
        }

    }
}
