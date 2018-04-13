namespace PetOwnerServiceclass
{
    using System.Configuration;
    using System.Net;
    using PetOwnersModel;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    public class PetOwnerList: IPetOwnerList
    {
        public List<Owner> getlist()
        {

            string URL = ConfigurationManager.AppSettings.Get("GetJsonURL");
            var client = new WebClient();
            var jsonData = string.Empty;
            jsonData = client.DownloadString(URL);
            var finalList = JsonConvert.DeserializeObject<List<Owner>>(jsonData);
            return finalList;
        }
        public  PetList sortjson(List<Owner> finalList)
        {
            PetList owner_list = new PetList();
            finalList.RemoveAll(c => c.Pets == null);

            var flatList = finalList.SelectMany(b => b.Pets.Select(p => new OwnerGenderPet
            {
                OwnerGender = b.Gender,
                PetName = p.Name,
                PetType = p.Type
            }

                )).ToList();
            flatList.RemoveAll(c => c.PetType.ToLower() != "cat");
            owner_list.GenderPets = flatList.OrderBy(c => c.PetName).ToList();
            return owner_list;
        }
    }
}
