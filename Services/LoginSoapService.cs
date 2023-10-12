using System.Text;
using System.Xml.Linq;

namespace UmbracoMekashronApplication.Services
{
    public class LoginSoapService : ISoapService
    {
        private readonly string SoapServeiceURI = "ЧЁ";
        public string ParseSoapResponse(string soapResponse)
        {
            XDocument xdoc = XDocument.Parse(soapResponse);
            var results = xdoc.Root.Value;
            return results;
        }


        public async Task<string> MakeSoapRequestAsync(string soapRequest)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(soapRequest, Encoding.UTF8, "text/xml");
                var response = await client.PostAsync(SoapServeiceURI, content);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
