namespace PetOwnerService
{
    using System.Configuration;
    using System.Net;
    
    public class Getlist
    {
        public  string getlist()
        {

            string URL = ConfigurationManager.AppSettings.Get("GetJsonURL");
            var client = new WebClient();
            var jsonData = string.Empty;
            jsonData = client.DownloadString(URL);
            return jsonData;
        }
    }
}
