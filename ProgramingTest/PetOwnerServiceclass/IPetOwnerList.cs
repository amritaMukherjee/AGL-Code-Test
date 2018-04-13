namespace PetOwnerServiceclass
{
    using PetOwnersModel;
    using System.Collections.Generic;
    public  interface IPetOwnerList
    {
        List<Owner> getlist();
        PetList sortjson(List<Owner> finalList);

    }
}
