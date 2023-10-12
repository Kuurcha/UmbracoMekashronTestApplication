using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoMekashronApplication.DTO;
using UmbracoMekashronApplication.model;

namespace UmbracoMekashronApplication.controller
{

    public class LoginController : UmbracoApiController
    {
        private readonly IMapper _mapper;

        public LoginController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public string ParseSoapResponse(string soapResponse)
        {
            XDocument xdoc = XDocument.Parse(soapResponse);
            var results = xdoc.Root.Value;
            return results;
        }
        public async Task<string> MakeSoapRequestAsync()
        {
            var soapEnvelope = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<env:Envelope xmlns:env=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns1=""urn:ICUTech.Intf-IICUTech"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:enc=""http://www.w3.org/2003/05/soap-encoding""><env:Body><ns1:Login env:encodingStyle=""http://www.w3.org/2003/05/soap-encoding""><UserName xsi:type=""xsd:string"">VictoriaDallon@parahumans.web</UserName><Password xsi:type=""xsd:string"">MultilimbedMonster</Password><IPs xsi:type=""xsd:string""></IPs></ns1:Login></env:Body></env:Envelope>";

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
            var response = await MakeSoapRequestAsync();

            var responseValue = ParseSoapResponse(response);

            var loginDetails = JsonSerializer.Deserialize<LoginReponse>(responseValue, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var loginDetailsDTO = _mapper.Map<LoginResponseDTO>(loginDetails);

            return Ok(loginDetailsDTO);
        }
    }
}
