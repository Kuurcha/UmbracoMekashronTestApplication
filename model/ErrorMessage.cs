namespace UmbracoMekashronApplication.model
{

    //{"ResultCode":-1,"ResultMessage":"User and password can not be empty"}

    public class ErrorMessage
    {
        private int resultCode;
        private string resultMessage;

        public string ResultMessage { get => resultMessage; set => resultMessage = value; }
        public int ResultCode { get => resultCode; set => resultCode = value; }
    }
}
