using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using userinfoApi.Models;

namespace userinfoApi.Controllers
{
    [EnableCors("Form")]
    [ApiController]
    [Route("[controller]")]
    public class FormController : Controller
    {
        [HttpPost]
        [Route("checkNewData")]
        public JsonResult checkNewData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new FormClass().GetCheckNewModels(userData, clientip));
        }

        [HttpPost]
        [Route("loginFormData")]
        public JsonResult loginFormData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd(), userAgent = Request.Headers["user-Agent"].ToString().TrimEnd();
            return Json(new FormClass().GetLoginFormModels(userData, clientip, userAgent));
        }

        [HttpPost]
        [Route("badgeFormData")]
        public JsonResult badgeFormData([FromBody] otherData otherData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new FormClass().GetBadgeFormModels(otherData, clientip));
        }

        [HttpPost]
        [Route("permissData")]
        public JsonResult permissData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new FormClass().GetPermissModels(userData, clientip));
        }

        [HttpPost]
        [Route("recordData")]
        public JsonResult recordData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new FormClass().GetRecordModels(userData, clientip));
        }

        [HttpPost]
        [Route("badgeData")]
        public JsonResult badgeData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new FormClass().GetBadgeModels(userData, clientip));
        }
    }
}
