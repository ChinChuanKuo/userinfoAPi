using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using userinfoApi.Models;

namespace userinfoApi.Controllers
{
    [EnableCors("Login")]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        [Route("checkUserData")]
        public JsonResult CheckUserData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new LoginClass().GetUserModels(userData, clientip));
        }

        [HttpPost]
        [Route("loginUserData")]
        public JsonResult LoginUserData([FromBody] loginData loginData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd(), userAgent = Request.Headers["user-Agent"].ToString().TrimEnd();
            return Json(new LoginClass().GetLoginModels(loginData, clientip, userAgent));
        }
    }
}