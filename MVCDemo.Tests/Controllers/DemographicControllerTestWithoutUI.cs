using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCDemo.Controllers;
using MVCDemo.Service;
using MVCDemo.Repository;
using MVCDemo.Models;
using MVCDemo.Domain;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;

namespace MVCDemo.Tests.Controllers
{
    [TestClass]
    public class DemographicControllerTestWithoutUI
    {
        [TestMethod]
        public void test_demographic_creation()
        {
            //Arrange
            DemographicController demoController = GetDemographicControllerObject();
            ViewResult resultBefore = demoController.Index() as ViewResult;
            int countBefore = ((List<Demographic>)resultBefore.Model).Count;
           
            Contact contact = new Contact
                        {
                            AddressLine1 = "123 randolph drive",
                            AddressLine2 = "Apt 1",
                            City = "Madison",
                            StateID = "IL",
                            ZipCode = "68717",
                            Email = "developer@domain.com"
                        };

            Demographic demographic = new Demographic
            {
                Member = new Member
                {
                    FirstName = "John-" + DateTime.Now.Date.ToShortDateString(),
                    LastName = "Doe",
                    Contacts = new List<Contact> { contact }
                },
                 HomeContact =  contact
            };


            //Act

            demoController.Create(demographic);
            
            
            //Assert
            ViewResult resultAfter = demoController.Index() as ViewResult;
            int countAfter = ((List<Demographic>)resultAfter.Model).Count;
            Assert.AreEqual(countAfter, countBefore + 1);
           
        }

        private static DemographicController GetDemographicControllerObject()
        {
            IUnitOfWork unitofWork;
            if(ConfigurationManager.AppSettings["UseDatabase"].ToUpper().ToString()=="TRUE")
                     unitofWork = new UnitOfWork();
            else
                unitofWork = new UnitOfWorkFake();
            DemographicService demoService = new DemographicService(unitofWork);
            StateService stateService = new StateService(unitofWork);
            DemographicController demoController = new DemographicController(demoService, stateService, unitofWork);
            return demoController;
        }

        [TestMethod]
        public void test_demographic_updation()
        {
            //Arrange
            DemographicController demoController = GetDemographicControllerObject();
            ViewResult resultGetBefore = demoController.Edit(2) as ViewResult;
            Demographic model = ((Demographic)resultGetBefore.Model);
            string _fname = DateTime.Now.ToLongTimeString();
            model.Member.FirstName = _fname;

            //Act
           
            ViewResult resultpost = demoController.Edit(model) as ViewResult;
            
           
            //Assert
            ViewResult resultGetAfter = demoController.Edit(2) as ViewResult;
            Assert.AreEqual(_fname, ((Demographic)resultGetAfter.Model).Member.FirstName);
        }
    }
}
