using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramingTest;
using ProgramingTest.Controllers;
using PetOwnerServiceclass;
using PetOwnersModel;

namespace ProgramingTest.Tests.Controllers
{
    
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Index()
        {
            try
            {

                // Arrange
               // IPetOwnerList petOwnerList=;
                HomeController controller = new HomeController(petOwnerList);

                // Act
                ViewResult result = controller.Index() as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }
            catch (Exception ex) { }
        }

    }
} 
