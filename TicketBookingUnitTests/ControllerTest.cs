using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticket_Booking;
using Ticket_Booking.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TicketBookingUnitTests
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void testIndex()
        {
            //Arrange
            HomeController homeController = new HomeController();

            //Act
            ViewResult result = homeController.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void testAbout()
        {
            //Arrange
            HomeController homeController = new HomeController();

            //Act
            ViewResult result = homeController.About() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void testContact()
        {
            //Arrange
            HomeController homeController = new HomeController();

            //Act
            ViewResult result = homeController.Contact() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }


    }
}
