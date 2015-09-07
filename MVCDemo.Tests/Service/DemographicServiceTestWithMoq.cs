using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVCDemo.Models;
using MVCDemo.Repository;
using MVCDemo.Service;
using System.Collections.Generic;
using System.Linq;

namespace MVCDemo.Tests.Service
{
    [TestClass]
    public class DemographicServiceTestWithMoq
    {
        [TestMethod]
        public void test_get_all()
        {
            //Arrange
            Mock<IUnitOfWork> mockUOW = new Mock<IUnitOfWork>();
            DemographicService DemographicService = new DemographicService(mockUOW.Object);
            mockUOW.Setup(s => s.MemberRepository.GetAll()).Returns(new List<Demographic> {  new Demographic()});
           
            //Act
            List<Demographic> list= DemographicService.GetAll();

            //Arrange
            Assert.AreEqual(1, list.Count());
        }

        [TestMethod]
        public void test_get_by_id()
        {
            //Arrange
            Mock<IUnitOfWork> mockUOW = new Mock<IUnitOfWork>();
            DemographicService DemographicService = new DemographicService(mockUOW.Object);
            mockUOW.Setup(m => m.MemberRepository.GetByID(It.IsAny<int>())).Returns(new Demographic());

            //Act
            DemographicService.GetByID(3);

            //Assert
            mockUOW.VerifyAll();
        }
    }
}
