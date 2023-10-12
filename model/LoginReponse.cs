namespace UmbracoMekashronApplication.model
{
    public class LoginReponse
    {
        private int entityId;

        private string firstName;

        private string lastName;

        private string company;

        private string adress;

        private string city;

        private string country;

        private string zip;

        private string phone;

        private string mobile;

        private string email;

        private int emailConfirm;

        private int mobileConfirm;

        private int countryId;

        private int status;

        private string lid;

        private string ftpHost;

        private int ftpPort;

        public LoginReponse()
        {
        }

        public LoginReponse(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int EntityId { get => entityId; set => entityId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Company { get => company; set => company = value; }
        public string Adress { get => adress; set => adress = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public string Zip { get => zip; set => zip = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Mobile { get => mobile; set => mobile = value; }
        public string Email { get => email; set => email = value; }
        public int EmailConfirm { get => emailConfirm; set => emailConfirm = value; }
        public int MobileConfirm { get => mobileConfirm; set => mobileConfirm = value; }
        public int CountryId { get => countryId; set => countryId = value; }
        public int Status { get => status; set => status = value; }
        public string Lid { get => lid; set => lid = value; }
        public string FtpHost { get => ftpHost; set => ftpHost = value; }
        public int FtpPort { get => ftpPort; set => ftpPort = value; }
    }
}
