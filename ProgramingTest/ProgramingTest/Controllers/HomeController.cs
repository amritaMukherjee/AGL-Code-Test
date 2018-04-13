namespace ProgramingTest.Controllers
{
    
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System;
    using PetOwnersModel;
    using PetOwnerServiceclass;
    public class HomeController : Controller
    {
        IPetOwnerList petOwnerList;
        public HomeController(IPetOwnerList repo)
        {
            this.petOwnerList = repo;
        }

        public ActionResult Index()
        {
            PetList owner_list = new PetList();
            try
            {
                var finalList = petOwnerList.getlist(); ;
                owner_list = petOwnerList.sortjson(finalList);
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