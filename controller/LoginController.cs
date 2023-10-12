using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoMekashronApplication.DTO;
using UmbracoMekashronApplication.model;
using UmbracoMekashronApplication.Services;

namespace UmbracoMekashronApplication.controller
{

    public class LoginController : UmbracoApiController
    {
        private readonly IMapper _mapper;
        private readonly ISoapService _soapSerivce;
        public LoginController(IMapper mapper, ISoapService soapService)
        {
            _mapper = mapper;
            _soapSerivce = soapService;
        }

        [HttpPost]
        public async Task<IActionResult> PostLoginAsync([FromBody] LoginDetails data)
        {

            var soapEnvelope = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <env:Envelope xmlns:env=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns1=""urn:ICUTech.Intf-IICUTech"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:enc=""http://www.w3.org/2003/05/soap-encoding""><env:Body><ns1:Login env:encodingStyle=""http://www.w3.org/2003/05/soap-encoding""><UserName xsi:type=""xsd:string"">{data.Email}</UserName><Password xsi:type=""xsd:string"">{data.Password}</Password><IPs xsi:type=""xsd:string""></IPs></ns1:Login></env:Body></env:Envelope>";

            var response = await _soapSerivce.MakeSoapRequestAsync(soapEnvelope);

            var responseValue = _soapSerivce.ParseSoapResponse(response);

            var errorDetails = JsonSerializer.Deserialize<ErrorMessage>(responseValue, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (errorDetails != null && errorDetails.ResultCode == -1)
            {
                return BadRequest(errorDetails);
            }
            else
            {
                var loginDetails = JsonSerializer.Deserialize<LoginReponse>(responseValue, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var loginDetailsDTO = _mapper.Map<LoginResponseDTO>(loginDetails);

                return Ok(loginDetailsDTO);
            }
        }
    }
}
