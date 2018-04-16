namespace ProgramingTest.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PetOwnerServiceclass;
    using PetOwnersModel;
    using Moq;
    using Newtonsoft.Json;
    using ProgramingTest.Controllers;
    using System.Web.Mvc;
    [TestClass]
    public class HomeControllerTest
    {             
        
        [TestMethod]
        public void SortListTest()
        {
              
                var petowner_service = new PetOwnerService();
                var People = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]}]";
                List<Owner> People_sort = JsonConvert.DeserializeObject<List<Owner>>(People);
                PetList petlist = new PetList();
                List<OwnerGenderPet> logp = new List<OwnerGenderPet>();
                OwnerGenderPet ogp = new OwnerGenderPet();

                ogp.OwnerGender = "Male";
                ogp.PetName = "Garfield";
                ogp.PetType = "Cat";
                logp.Add(ogp);
                OwnerGenderPet ogp1 = new OwnerGenderPet();
                ogp1.OwnerGender = "Female";
                ogp1.PetName = "Garfield";
                ogp1.PetType = "Cat";
                logp.Add(ogp1);
                
                petlist.GenderPets = logp;
                             
                PetList resultList2 = petowner_service.SortList(People_sort);
                if(resultList2.GenderPets.Count==petlist.GenderPets.Count)
                    for (int i = 0; i < resultList2.GenderPets.Count; i++)
                    {
                        if (resultList2.GenderPets[i].OwnerGender == petlist.GenderPets[i].OwnerGender)
                        {
                            if (resultList2.GenderPets[i].PetName == petlist.GenderPets[i].PetName)
                            {
                                if (resultList2.GenderPets[i].PetType == petlist.GenderPets[i].PetType) ;
                                //Test passed
                            }

                        }

                    }
            Assert.AreEqual(resultList2.GenderPets.Count, petlist.GenderPets.Count);

            }
        

        [TestMethod]
        public void IndexTest()
        {
             var mock = new Mock<IPetOwnerservice>();
            var controller = new HomeController(mock.Object);

            var People = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]}]";
            var People_sort = JsonConvert.DeserializeObject<List<Owner>>(People);
            PetList petlist = new PetList();
            List<OwnerGenderPet> logp = new List<OwnerGenderPet>();
            OwnerGenderPet ogp = new OwnerGenderPet();

            ogp.OwnerGender = "Male";
            ogp.PetName = "Garfield";
            ogp.PetType = "Cat";
            logp.Add(ogp);
            OwnerGenderPet ogp1 = new OwnerGenderPet();
            ogp1.OwnerGender = "Female";
            ogp1.PetName = "Garfield";
            ogp1.PetType = "Cat";
            logp.Add(ogp1);

            petlist.GenderPets = logp;
            mock.Setup(x => x.DownloadJsonlist()).Returns(People_sort);
            mock.Setup(y => y.SortList(People_sort)).Returns(petlist);

            var actual = controller.Index() as ViewResult;
            var model = actual.ViewData.Model as PetList;

            Assert.AreEqual(2, model.GenderPets.Count);

        }

    }
} 
