using System.Web.Mvc;
using System;
using PetOwnersModel;
using PetOwnerServiceclass;
using ProgramingTest.LoggingService;
namespace ProgramingTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logingservice;
        private readonly IPetOwnerservice _petOwnerList;

        public HomeController(IPetOwnerservice repo,ILogger logs)
        {
            _petOwnerList = repo;
            _logingservice = logs;
        }

        public ActionResult Index()
        {
            var owner_list = new PetList();
            try
            {
                var finalList = _petOwnerList.DownloadJsonlist(); ;
                owner_list = _petOwnerList.SortList(finalList);
               
            }
            catch (Exception ex)
            {
                _logingservice.ErrorLogger(ex);
            }
            return View(owner_list);

        }
       

    }
}