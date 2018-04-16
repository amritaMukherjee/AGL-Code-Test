namespace ProgramingTest.Controllers
{
    using System.Web.Mvc;
    using System;
    using PetOwnersModel;
    using PetOwnerServiceclass;
    public class HomeController : Controller
    {
        IPetOwnerservice petOwnerList;
        public HomeController(IPetOwnerservice repo)
        {
            this.petOwnerList = repo;
        }

        public ActionResult Index()
        {
            PetList owner_list = new PetList();
            try
            {
                var finalList = petOwnerList.DownloadJsonlist(); ;
                owner_list = petOwnerList.SortList(finalList);
            }
            catch (Exception ex)
            {
                Logger.Logger logerror = new Logger.Logger();
                logerror.ErrorLogger(ex);
            }

            return View(owner_list);
        }
        


    }
}