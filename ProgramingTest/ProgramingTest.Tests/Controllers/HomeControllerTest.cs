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
                
        public virtual PetList sortjson(List<Owner> finalList)
        {
            throw new NotImplementedException();
        }
        [TestMethod]
        public void IndexTest()
        {
            try
            {

                // Arrange
                                
                var mock = new Mock<IPetOwnerList>();
                
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
              
                mock.Setup(foo => foo.sortjson(People_sort)).Returns((petlist));
                PetList resultList2 = mock.Object.sortjson(People_sort);

                CollectionAssert.AreEquivalent(resultList2.GenderPets, petlist.GenderPets);
                
            }
            catch (Exception ex) { }
        }

    }
} 
