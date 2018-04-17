using PetOwnersModel;
using System.Collections.Generic;
namespace PetOwnerServiceclass
{
    public interface IPetOwnerservice
    {
        List<Owner> DownloadJsonlist();
        PetList SortList(List<Owner> finalList);
    }
}
