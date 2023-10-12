using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml.Linq;
using Umbraco.Cms.Web.Common.Controllers;

namespace UmbracoMekashronApplication.controller
{

    public class LoginController : UmbracoApiController
    {
        public string ParseSoapResponse(string soapResponse)
        {
            XDocument xdoc = XDocument.Parse(soapResponse);
            /*            XNamespace ns = xdoc.Root.GetNamespaceOfPrefix("ns1");
            */
            var results = xdoc.Root.Value;
            return results;
            /*            XNamespace ns = "http://www.w3.org/2003/05/soap-envelope";
                    XNamespace webNs = "http://isapi.icu-tech.com/icutech-test.dll/soap/IICUTech";


                    IEnumerable<XElement> result = xdoc.Descendants(ns + "Body");
                    var elementCount = result.Count();
                    foreach (XElement element in result)
                    {
                        Console.WriteLine(element.Value.ToString());
                    }*/
            // Process the result as needed.
        }
        public async Task<string> MakeSoapRequestAsync()
        {
            var soapEnvelope = @"<?xml version=""1.0"" encoding=""UTF-8""?> <env:Envelope xmlns:env=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns1=""urn:ICUTech.Intf-IICUTech"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:enc=""http://www.w3.org/2003/05/soap-encoding""><env:Body><ns1:GetVersion env:encodingStyle=""http://www.w3.org/2003/05/soap-encoding""/></env:Body></env:Envelope>";

            using (var client = new HttpClient())
            {
                var content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
                var response = await client.PostAsync("http://isapi.icu-tech.com/icutech-test.dll/soap/IICUTech", content);

                return await response.Content.ReadAsStringAsync();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLoginAsync()
        {
            /*            HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.OK, response);*/
            // Your logic here
            var response = await MakeSoapRequestAsync();

            return Ok(ParseSoapResponse(response));
        }
    }
}
