using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using userinfoApi.Models;

namespace userinfoApi.Controllers
{
    [EnableCors("Icon")]
    [ApiController]
    [Route("[controller]")]
    public class IconController : Controller
    {
        [HttpPost]
        [Route("searchData")]
        public JsonResult searchData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new IconClass().GetSearchModels(userData, clientip));
        }

        [HttpPost]
        [Route("insertData")]
        public JsonResult insertData([FromBody] iIconData iIconData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new IconClass().GetInsertModels(iIconData, clientip));
        }
    }
}