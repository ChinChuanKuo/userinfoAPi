using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using userinfoApi.Models;

namespace userinfoApi.Controllers
{
    [EnableCors("Forget")]
    [ApiController]
    [Route("[controller]")]
    public class ForgetController : Controller
    {
        [HttpPost]
        public JsonResult forgetUserData([FromBody] otherData otherData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new ForgetClass().GetForgetUserModels(otherData, clientip));
        }
    }
}