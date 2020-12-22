using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using userinfoApi.Models;

namespace userinfoApi.Controllers
{
    [EnableCors("Code")]
    [ApiController]
    [Route("[controller]")]
    public class CodeController : Controller
    {
        [HttpPost]
        [Route("codeUserData")]
        public JsonResult codeUserData([FromBody] otherData otherData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new CodeClass().GetCodeUserModels(otherData, clientip));
        }
    }
}
