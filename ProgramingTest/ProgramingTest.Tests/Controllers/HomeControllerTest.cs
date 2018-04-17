namespace ProgramingTest.Tests.Controllers
{
    
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PetOwnerServiceclass;
    using PetOwnersModel;
    using Moq;
    using Newtonsoft.Json;
    using ProgramingTest.Controllers;
    using System.Web.Mvc;
    using LoggingService;
    
    [TestClass]
    public class HomeControllerTest
    {             
        
        [TestMethod]
        public void SortListTest()
        {
              
            var petownerService = new PetOwnerService();
            var people = JsonConvert.DeserializeObject<List<Owner>>
             ("[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Jerry\",\"type\":\"Cat\"}]}]");


            var expectedPetList = new PetList
            {
                GenderPets = new List<OwnerGenderPet>()
            };
            expectedPetList.GenderPets.Add(new OwnerGenderPet
            {
                OwnerGender = "Female",
                PetName = "Jerry",
                PetType = "Cat"
            });
            expectedPetList.GenderPets.Add(new OwnerGenderPet
            {
                OwnerGender = "Male",
                PetName = "Tom",
                PetType = "Cat"
            });

            var actualList = petownerService.SortList(people);
                
            Assert.AreEqual(expectedPetList.GenderPets.Count, actualList.GenderPets.Count);
            Assert.IsTrue(expectedPetList.GenderPets[0].PetName.Equals(actualList.GenderPets[0].PetName));
            Assert.IsTrue(expectedPetList.GenderPets[0].PetType.Equals(actualList.GenderPets[0].PetType));
            Assert.IsTrue(expectedPetList.GenderPets[0].OwnerGender.Equals(actualList.GenderPets[0].OwnerGender));

            Assert.IsTrue(expectedPetList.GenderPets[1].PetName.Equals(actualList.GenderPets[1].PetName));
            Assert.IsTrue(expectedPetList.GenderPets[1].PetType.Equals(actualList.GenderPets[1].PetType));
            Assert.IsTrue(expectedPetList.GenderPets[1].OwnerGender.Equals(actualList.GenderPets[1].OwnerGender));


        }
        

        [TestMethod]
        public void IndexTest()
        {
             var mock = new Mock<IPetOwnerservice>();
            var mocklogger = new Mock<ILogger>();
                      
            var People = JsonConvert.DeserializeObject<List<Owner>>
                ( "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]}]");
            
            
            var expectedPetList = new PetList
            {
                GenderPets = new List<OwnerGenderPet>()
            };
            expectedPetList.GenderPets.Add(new OwnerGenderPet
            {
                OwnerGender = "Female",
                PetName = "Garfield",
                PetType = "Cat"
            });
            expectedPetList.GenderPets.Add(new OwnerGenderPet
            {
                OwnerGender = "Male",
                PetName = "Tom",
                PetType = "Cat"
            });
            

                       
            mock.Setup(x => x.DownloadJsonlist()).Returns(People);
            mock.Setup(y => y.SortList(People)).Returns(expectedPetList);
            var controller = new HomeController(mock.Object, mocklogger.Object);
            var actual = controller.Index() as ViewResult;
            var model = actual.ViewData.Model as PetList;
            Assert.AreEqual(2, model.GenderPets.Count);


        }

    }
} 
