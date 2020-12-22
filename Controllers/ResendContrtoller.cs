using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using userinfoApi.Models;

namespace userinfoApi.Controllers
{
    [EnableCors("Resend")]
    [ApiController]
    [Route("[controller]")]
    public class ResendController : Controller
    {
        [HttpPost]
        [Route("resendUserData")]
        public JsonResult resendUserData([FromBody] otherData otherData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new ResendClass().GetResendUserModels(otherData, clientip));
        }
    }
}