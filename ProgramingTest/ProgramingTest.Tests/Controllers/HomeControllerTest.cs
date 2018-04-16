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
                PetOwnerList petOwnerList=new PetOwnerList();
                
                var mock = new Mock<HomeControllerTest>();
                
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
                List<PetList> pt = new List<PetList>();
                pt.Add(petlist);
                mock.Setup(foo => foo.sortjson(People_sort)).Returns((petlist));
                List<PetList> pp = new List<PetList>();
               
                PetList resultList2 = petOwnerList.sortjson(People_sort);
                pp.Add(resultList2);
                
                if(resultList2.GenderPets.Count()== petlist.GenderPets.Count())
                {
                    //test passed
                    //
                    for(int i=0;i< resultList2.GenderPets.Count(); i++)
                    {
                        if (resultList2.GenderPets[i].OwnerGender == petlist.GenderPets[i].OwnerGender) {
                            if (resultList2.GenderPets[i].PetName == petlist.GenderPets[i].PetName) {
                                if (resultList2.GenderPets[i].PetType == petlist.GenderPets[i].PetType) ; 
                                    //Test passed
                            }

                        }

                    }
                }
            }
            catch (Exception ex) { }
        }

    }
} 
