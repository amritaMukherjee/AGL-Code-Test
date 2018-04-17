using System.Collections.Generic;
namespace PetOwnersModel
{
     
    public class PetList
    {
        public List<OwnerGenderPet> GenderPets { get; set; }
    }
    public class Owner
    {
        public string Gender { get; set; }

        public List<Pet> Pets { get; set; }
    }
    public class OwnerGenderPet
    {
        public string OwnerGender { get; set; }

        public string PetType { get; set; }

        public string PetName { get; set; }
    }
    public class Pet
    {
        public string Type { get; set; }

        public string Name { get; set; }
    }
}