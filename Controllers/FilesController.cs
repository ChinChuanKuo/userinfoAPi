using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using userinfoApi.Models;

namespace userinfoApi.Controllers
{
    [EnableCors("Files")]
    [ApiController]
    [Route("[controller]")]
    public class FilesController : Controller
    {
        [HttpPost]
        [Route("websiteData")]
        public JsonResult websiteData([FromBody] sRowsData sRowsData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd(), userAgent = Request.Headers["user-Agent"].ToString().TrimEnd();
            return Json(new FilesClass().GetWebsiteModels(sRowsData, clientip, userAgent));
        }

        [HttpPost]
        [Route("downloadData")]
        public JsonResult downloadData([FromBody] sRowsData sRowsData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd(), userAgent = Request.Headers["user-Agent"].ToString().TrimEnd();
            return Json(new FilesClass().GetDownloadModels(sRowsData, clientip, userAgent));
        }

        [HttpPost]
        [System.Obsolete]
        [Route("transferData")]
        public JsonResult transferData([FromBody] sFileData sFileData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd(), userAgent = Request.Headers["user-Agent"].ToString().TrimEnd();
            return Json(new FilesClass().GetTransferModels(sFileData, clientip));
        }
    }
}
