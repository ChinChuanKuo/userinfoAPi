using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using userinfoApi.Models;

namespace userinfoApi.Controllers
{
    [EnableCors("Signup")]
    [ApiController]
    [Route("[controller]")]
    public class SignupController : Controller
    {
        [HttpPost]
        [Route("signupUserData")]
        public JsonResult signupUserData([FromBody] signupData signupData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new SignupClass().GetSignupUserModels(signupData, clientip));
        }
    }
}