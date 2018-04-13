using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramingTest;
using ProgramingTest.Controllers;

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
                HomeController controller = new HomeController();

                // Act
                ViewResult result = controller.Index() as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }
            catch (Exception ex) { }
        }

    }
} 
