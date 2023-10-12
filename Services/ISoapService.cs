namespace UmbracoMekashronApplication.Services
{
    public interface ISoapService
    {
        Task<string> MakeSoapRequestAsync(string soapRequest);

        string ParseSoapResponse(string soapResponse);
    }
}
