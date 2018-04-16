namespace PetOwnerServiceclass
{
    using PetOwnersModel;
    using System.Collections.Generic;
    public  interface IPetOwnerservice
    {
        List<Owner> DownloadJsonlist();
        PetList SortList(List<Owner> finalList);
        


    }
}
