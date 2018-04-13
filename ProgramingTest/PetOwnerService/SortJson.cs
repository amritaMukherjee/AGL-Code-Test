namespace PetOwnerService
{
  
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
   
    public  static class SortJson
    {
        public static PetList sortjson(List<Owner> finalList) {
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