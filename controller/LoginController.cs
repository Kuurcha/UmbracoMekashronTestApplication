using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common.Controllers;

namespace UmbracoMekashronApplication.controller
{
    public class LoginController : UmbracoApiController
    {
        [HttpGet]
        public IActionResult GetLogin()
        {
            /*            HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.OK, response);*/
            // Your logic here
            return NotFound("This is a failed response");
        }
    }
}
