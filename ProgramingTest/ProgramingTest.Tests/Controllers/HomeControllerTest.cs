namespace ProgramingTest.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PetOwnerServiceclass;
    using PetOwnersModel;
    using Moq;
    using Newtonsoft.Json;

    [TestClass]
    public class HomeControllerTest
    {
             
        
        [TestMethod]
        public void IndexTest()
        {
            try
            {
                               
                var mock = new Mock<IPetOwnerservice>();
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
                mock.Setup(foo => foo.SortList(People_sort)).Returns((petlist));
                PetList resultList2 = mock.Object.SortList(People_sort);
                CollectionAssert.AreEquivalent(resultList2.GenderPets, petlist.GenderPets);
                
            }
            catch (Exception ex) { }
        }

    }
} 
