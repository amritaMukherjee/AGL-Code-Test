namespace ProgramingTest.Controllers
{
    using System.Web.Mvc;
    using System;
    using PetOwnersModel;
    using PetOwnerServiceclass;
    using LoggingService;
    public class HomeController : Controller
    {
        IPetOwnerservice petOwnerList;
        ILogger logingservice;
        public HomeController(IPetOwnerservice repo,ILogger logs)
        {
            this.petOwnerList = repo;
            this.logingservice = logs;
        }

        public ActionResult Index()
        {
            var owner_list = new PetList();
            try
            {
                var finalList = petOwnerList.DownloadJsonlist(); ;
                owner_list = petOwnerList.SortList(finalList);
               
            }
            catch (Exception ex)
            {
                 logingservice.ErrorLogger(ex);
            }
            return View(owner_list);

        }
        


    }
}