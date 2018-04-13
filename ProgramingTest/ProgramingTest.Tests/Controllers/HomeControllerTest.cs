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
using Moq;
using Newtonsoft.Json;

namespace ProgramingTest.Tests.Controllers
{
    
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        public virtual List<Owner> getlist()
        {
            throw new NotImplementedException();
        }
        
        public virtual PetList sortjson(List<Owner> finalList)
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void Index()
        {
            try
            {

                // Arrange
                PetOwnerList petOwnerList=new PetOwnerList();
                HomeController controller = new HomeController(petOwnerList);
                var mock = new Mock<HomeControllerTest>();
                               
                var People = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";
                
                // Act
                var People_sort = JsonConvert.DeserializeObject<List<Owner>>(People);
                mock.Setup(foo => foo.getlist()).Returns((People_sort));
                var resultList = mock.Object.getlist();
                CollectionAssert.AreEquivalent(People_sort, resultList);

                People= "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]}]";
                 People_sort = JsonConvert.DeserializeObject<List<Owner>>(People);
                PetList petlist = new PetList();
                List<OwnerGenderPet> logp = new List<OwnerGenderPet>();
                   
                OwnerGenderPet ogp = new OwnerGenderPet();
              
                ogp.OwnerGender = "Male";
                ogp.PetName = "Garfield";
                ogp.PetType = "Cat";
                logp.Add(ogp);
                              
                ogp.OwnerGender = "Female";
                ogp.PetName = "Garfield";
                ogp.PetType = "Cat";

                logp.Add(ogp);

                petlist.GenderPets = logp;
                List<PetList> pt = new List<PetList>();
                pt.Add(petlist);
                mock.Setup(foo => foo.sortjson(People_sort)).Returns((petlist));
                List<PetList> pp = new List<PetList>();
               
                PetList resultList2 = mock.Object.sortjson(People_sort);
                pp.Add(resultList2);
                CollectionAssert.AreEquivalent(pt, pp);

               // ActionResult result = controller.Index() as ActionResult;

                // Assert
               // Assert.IsNotNull(result);
            }
            catch (Exception ex) { }
        }

    }
} 
