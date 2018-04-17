using System.Configuration;
using System.Net;
using PetOwnersModel;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
namespace PetOwnerServiceclass
{
    public class PetOwnerService : IPetOwnerservice
    {
        public List<Owner> DownloadJsonlist()
        {
            string url = ConfigurationManager.AppSettings.Get("GetJsonURL");
            var jsonData = string.Empty;
            var client = new WebClient();
            jsonData = client.DownloadString(url);
            var finalList = JsonConvert.DeserializeObject<List<Owner>>(jsonData);
            return finalList;
        }
        public  PetList SortList(List<Owner> finalList)
        {
            PetList PetList = new PetList();
            finalList.RemoveAll(c => c.Pets == null);

            var flatList = finalList.SelectMany(b => b.Pets.Select(p => new OwnerGenderPet
            {
                OwnerGender = b.Gender,
                PetName = p.Name,
                PetType = p.Type
            }

                )).ToList();
            flatList.RemoveAll(c => c.PetType.ToLower() != "cat");
            PetList.GenderPets = flatList.OrderBy(c => c.PetName).ToList();
            return PetList;
        }

    }
}
