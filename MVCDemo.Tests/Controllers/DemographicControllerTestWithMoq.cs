using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCDemo.Controllers;
using MVCDemo.Domain;
using MVCDemo.Models;
using MVCDemo.Repository;
using MVCDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCDemo.Tests.Controllers
{
    [TestClass]
    public class DemographicControllerTestWithMoq
    {
        [TestMethod]
        public void test_index()
        {

            //Arrange
            Mock<IUnitOfWork> mockUOW = new Mock<IUnitOfWork>();
            Mock<DemographicService> mockDemoService = new Mock<DemographicService>(mockUOW.Object);
            Mock<StateService> mockStateervice = new Mock<StateService>(mockUOW.Object);
            DemographicController target = new DemographicController(mockDemoService.Object, mockStateervice.Object, mockUOW.Object);
            mockDemoService.Setup(d => d.GetAll()).Returns(new List<Demographic> { new Demographic(), new Demographic() });

            //Act
            ViewResult result = target.Index() as ViewResult;


            //Assert
            //mockDemoService.Verify();

            Assert.AreEqual(2, ((List<Demographic>)result.Model).Count());

        }
        [TestMethod]
        public void test_edit_get()
        {
            //Arrange
            Mock<IUnitOfWork> mockUOW = new Mock<IUnitOfWork>();
            Mock<DemographicService> mockDemoService = new Mock<DemographicService>(mockUOW.Object);
            Mock<StateService> mockStateService = new Mock<StateService>(mockUOW.Object);
            DemographicController target = new DemographicController(mockDemoService.Object, mockStateService.Object, mockUOW.Object);
            mockDemoService.Setup(s => s.GetByID(It.IsAny<int>())).Returns(new Demographic { Member = new Member { FirstName = "John" } });
            mockStateService.Setup(s => s.GetStateList()).Returns(new List<State> { new State { StateID = "WI" } });
            //Act
            ViewResult result = target.Edit(2) as ViewResult;

            //Assert
            //Assert.IsNotNull(result);
            Assert.IsTrue(("John" == ((Demographic)result.Model).Member.FirstName) && ((Demographic)result.Model).StateList.Count() == 1);
        }
        [TestMethod]
        public void test_create_get()
        {
            //Arrange
            Mock<IUnitOfWork> mockUOW = new Mock<IUnitOfWork>();
            Mock<DemographicService> mockDemoService = new Mock<DemographicService>(mockUOW.Object);
            Mock<StateService> mockStateService = new Mock<StateService>(mockUOW.Object);
            DemographicController target = new DemographicController(mockDemoService.Object, mockStateService.Object, mockUOW.Object);
            
            mockStateService.Setup(s => s.GetStateList()).Returns(()=>new List<State>{new State{ StateID="WI"}});
            //Act
            var result = (ViewResult)target.Create();


            //assert
            Assert.IsTrue(((Demographic)result.Model) != null && ((Demographic)result.Model).StateList.Count() == 1);

        }
        [TestMethod]
        public void test_create_post_throws_exception()
        {
            //Arrange
            Mock<IUnitOfWork> mockUOW = new Mock<IUnitOfWork>();
            Mock<DemographicService> mockDemoService = new Mock<DemographicService>(mockUOW.Object);
            Mock<StateService> mockStateService = new Mock<StateService>(mockUOW.Object);
            DemographicController target = new DemographicController(mockDemoService.Object, mockStateService.Object, mockUOW.Object);
            mockDemoService.Setup(d => d.Save(It.IsAny<Demographic>())).Throws<Exception>();
            mockStateService.Setup(s => s.GetStateList()).Returns(() => new List<State> { new State { StateID = "WI" }, new State { StateID = "IL" } });
           
            //Act
           
            var result = (ViewResult)target.Create(new Demographic());

            //assert
            ModelState modelState = result.ViewData.ModelState[""];
            Assert.IsTrue(modelState.Errors.Any());
            Assert.IsTrue(((Demographic)result.Model).StateList.Count() == 2);
            
        
        }
        [TestMethod]
        public void test_create_post_successful()
        {
            //Arrange
            Mock<IUnitOfWork> mockUOW = new Mock<IUnitOfWork>();
            Mock<DemographicService> mockDemoService = new Mock<DemographicService>(mockUOW.Object);
            Mock<StateService> mockStateService = new Mock<StateService>(mockUOW.Object);
            DemographicController target = new DemographicController(mockDemoService.Object, mockStateService.Object, mockUOW.Object);
            mockDemoService.Setup(d => d.Save(It.IsAny<Demographic>()));
            mockStateService.Setup(s => s.GetStateList()).Returns(() => new List<State> { new State { StateID = "WI" }, new State { StateID = "IL" } });

            //Act
            var result = (RedirectToRouteResult)target.Create(new Demographic());


            //assert
            Assert.AreEqual("index", result.RouteValues.Values.ToList()[0].ToString());


        }
    }
}
