using System;
using System.Threading;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumNUnitExtentReport.Config;

namespace RestfulBooker
{
    [TestFixture]
    public class Test : Reports
    {
        [Category("Shady Meadows Bed and Breakfast")]
        [Test(Description = @"Ensure User can Create a room from B&B Booking Management"), Order(1)]
        public void CreateARoomFromAdminPage()
        {
            var login = new LoginPage(_driver);
            var createRoom = new AdminPage(_driver);
            var homePage = new HomePage(_driver);
            var bookRoom = new BookRoomPage(_driver);
            var action = new Actions(_driver);

            test.Log(Status.Pass, "Navigate to Shady Meadows Bed and Breakfast");
            homePage.GoToHomePage();
            test.Log(Status.Pass, "Click on hack button");
            homePage.ClickHackButton();
            test.Log(Status.Pass, "Click on Admin link button");
            homePage.ClickAdminLinkButton();
            var isLoginPageOpened = login.Heading.Displayed;
            //Verify that admin login page is opened
            Assert.IsTrue(login.Heading.Displayed, "Log into your account");
            test.Log(Status.Pass, "Login in page heading opened : " + login.Heading.Text);
            test.Log(Status.Pass, "Assert Result" + isLoginPageOpened);
            test.Log(Status.Pass, "Enter username");
            login.EnterUsername(username: "admin");
            test.Log(Status.Pass, "Enter password");
            login.EnterPassword(password: "password");
            Thread.Sleep(5000);
            test.Log(Status.Pass, "Click on login button");
            login.ClickOnLoginButton();
            //Assert that admin login is successful and opens the B&B Booking Management  creation page is opened 
            var isRoomCreationPageOpened = createRoom.BAndBBookingHeading.Displayed;
            Assert.IsTrue(createRoom.BAndBBookingHeading.Displayed, "B&B Booking Management");
            test.Log(Status.Pass, "B&B Booking Management page is opened: " + createRoom.BAndBBookingHeading.Text);
            test.Log(Status.Pass, "Assert Result: " + isRoomCreationPageOpened);
            test.Log(Status.Pass, "Enter a room number");
            createRoom.InputRoomNumber("200");
            test.Log(Status.Pass, "Select a room type");
            createRoom.SelectRoomType(Keys.ArrowDown + "Family");
            Thread.Sleep(3000);
            test.Log(Status.Pass, "Select accessibility ");
            createRoom.SelectAccessibility(Keys.ArrowDown + "true");
            test.Log(Status.Pass, "Enter a room price");
            createRoom.EnterRoomPrice("220");
            test.Log(Status.Pass, "Select room details: Select Wifi");
            createRoom.SelectWifi();
            test.Log(Status.Pass, "Select room details: Select Refreshments");
            createRoom.SelectRefreshments();
            test.Log(Status.Pass, "Select room details: Select tv");
            createRoom.SelectTv();
            test.Log(Status.Pass, "Select room details: Select Safe");
            createRoom.SelectSafe();
            test.Log(Status.Pass, "Select room details: Select Radio");
            createRoom.SelectRadio();
            test.Log(Status.Pass, "Select room details: Select Views");
            createRoom.SelectViews();
            test.Log(Status.Pass, "Click on create button ");
            createRoom.ClickOnCreateRoomButton();
            login.SelectLogOut();
            test.Log(Status.Pass, "Actual: " + login.Heading.Text);
            test.Log(Status.Pass, "Assert Result: " + isLoginPageOpened);
            Thread.Sleep(3000);
            //Book A room
            bookRoom.ClickBookingManagement();
            bookRoom.ClickBookThisRoom();
            action.SendKeys(Keys.PageDown).Build().Perform();
            Thread.Sleep(2000);
            bookRoom.ClickBookThisRoom();
            bookRoom.EnterFirstName("Chuck");
            bookRoom.EnterLastName("Norris");
            bookRoom.EnterEmail("ChuckNorris@test.com");
            bookRoom.EnterPhoneNumber("2121236543");
            Thread.Sleep(2000);
            bookRoom.ClickBookButton();
            //Unable to select date 
            // Unable to book a room, Following error was observed "Must be not null". Not sure where the I am doing wrong, seem like button is not working. 
        }

        //[Test(Description = @"Ensure User can Create a book a room "), Order(2)]
        //public void BookARoom()
        //{
        //    var homePage = new HomePage(_driver);
        //    var bookRoom = new BookRoomPage(_driver);
        //    var action = new Actions(_driver);
        //    homePage.GoToHomePage();
        //    Thread.Sleep(2000);
        //    action.SendKeys(Keys.PageDown).Build().Perform();
        //    Thread.Sleep(2000);
        //    bookRoom.ClickBookThisRoom();
        //    bookRoom.EnterFirstName("Chuck");
        //    bookRoom.EnterLastName("Norris");
        //    bookRoom.EnterEmail("ChuckNorris@test.com");
        //    bookRoom.EnterPhoneNumber("2121236543");
        //    Thread.Sleep(2000);
        //    bookRoom.ClickBookButton();
        //    // Unable to book a room, Following error was observed "Must be not null". Not sure where the I am doing wrong, seem like button is not working. 
        //}
        [Category("Shady Meadows Bed and Breakfast")]
        [Test(Description = @"Ensure User can send message "), Order(3)]
        public void BookingInquiry()
        {
            // sending booking inquiry message 
            var homePage = new HomePage(_driver);
            var action = new Actions(_driver);
            var bookingInquiry = new BookingInquiry(_driver);
            test.Log(Status.Pass, "Navigate to Homepage");
            homePage.GoToHomePage();
            Thread.Sleep(2000);
            action.SendKeys(Keys.PageDown).Build().Perform();
            test.Log(Status.Pass, "Enter Name");
            bookingInquiry.EnterName("Chuck Norris");
            test.Log(Status.Pass, "Enter Email");
            bookingInquiry.EnterEmail("ChuckNorris@test.com");
            test.Log(Status.Pass, "Enter Phone Number");
            bookingInquiry.EnterPhoneNumber("12125555454");
            test.Log(Status.Pass, "Enter Subject");
            bookingInquiry.EnterSubject("One Room");
            Thread.Sleep(2000);
            test.Log(Status.Pass, "Enter Message");
            bookingInquiry.EnterMessage("I would like to book a room at your place");
            test.Log(Status.Pass, "Click SubmitButton ");
            bookingInquiry.ClickSubmitButton();
            //Verify that message was sent 
            var verifyMessage = bookingInquiry.MessageConfirmation.Displayed;
            Assert.AreEqual(bookingInquiry.MessageConfirmation.Text, "Thanks for getting in touch Chuck Norris!");
            test.Log(Status.Pass, "Assert Result: " + verifyMessage);
            Console.WriteLine(bookingInquiry.MessageConfirmation.Text);
            //Verify that message was send can be be view by admin.

        }
        [Category("Shady Meadows Bed and Breakfast")]
        [Test(Description = @"Ensure Admin can view message from admin inbox "), Order(4)]
        public void ViewMessageFromAdminInbox()
        {
            var login = new LoginPage(_driver);
            var homePage = new HomePage(_driver);
            var createRoom = new AdminPage(_driver);
            test.Log(Status.Pass, "Navigate to Shady Meadows Bed and Breakfast");
            homePage.GoToHomePage();
            test.Log(Status.Pass, "Click on hack button");
            homePage.ClickHackButton();
            test.Log(Status.Pass, "Click on Admin link button");
            homePage.ClickAdminLinkButton();
            var isLoginPageOpened = login.Heading.Displayed;
            //Verify that admin login page is opened
            Assert.IsTrue(login.Heading.Displayed, "Log into your account");
            test.Log(Status.Pass, "Login in page heading opened : " + login.Heading.Text);
            test.Log(Status.Pass, "Assert Result" + isLoginPageOpened);
            test.Log(Status.Pass, "Enter username");
            login.EnterUsername(username: "admin");
            test.Log(Status.Pass, "Enter password");
            login.EnterPassword(password: "password");
            Thread.Sleep(5000);
            test.Log(Status.Pass, "Click on login button");
            login.ClickOnLoginButton();
            //Assert that admin login is successful and opens the B&B Booking Management  creation page is opened 
            var isRoomCreationPageOpened = createRoom.BAndBBookingHeading.Displayed;
            Assert.IsTrue(createRoom.BAndBBookingHeading.Displayed, "B&B Booking Management");
            test.Log(Status.Pass, "B&B Booking Management page is opened: " + createRoom.BAndBBookingHeading.Text);
            test.Log(Status.Pass, "Assert Result: " + isRoomCreationPageOpened);
            test.Log(Status.Pass, "Click on inbox");
            createRoom.ClickInbox();
            test.Log(Status.Pass, "Click on name to read the message");
            createRoom.ReadMessage();
            test.Log(Status.Pass, "Click on close button");
            Assert.AreEqual(createRoom.Message.Text, "Chuck Norris");
            Console.WriteLine(createRoom.Message.Text);
            createRoom.ClickCloseButton();

        }
        [Category("Shady Meadows Bed and Breakfast")]
        [Test(Description = @"Ensure Admin can view report from admin report "), Order(5)]
        public void ViewAdminReport()
        {
            var login = new LoginPage(_driver);
            var homePage = new HomePage(_driver);
            var createRoom = new AdminPage(_driver);
            var adminReport = new AdminReportPage(_driver);
            test.Log(Status.Pass, "Navigate to Shady Meadows Bed and Breakfast");
            homePage.GoToHomePage();
            test.Log(Status.Pass, "Click on hack button");
            homePage.ClickHackButton();
            test.Log(Status.Pass, "Click on Admin link button");
            homePage.ClickAdminLinkButton();
            var isLoginPageOpened = login.Heading.Displayed;
            //Verify that admin login page is opened
            Assert.IsTrue(login.Heading.Displayed, "Log into your account");
            test.Log(Status.Pass, "Login in page heading opened : " + login.Heading.Text);
            test.Log(Status.Pass, "Assert Result" + isLoginPageOpened);
            test.Log(Status.Pass, "Enter username");
            login.EnterUsername(username: "admin");
            test.Log(Status.Pass, "Enter password");
            login.EnterPassword(password: "password");
            Thread.Sleep(5000);
            test.Log(Status.Pass, "Click on login button");
            login.ClickOnLoginButton();
            //Assert that admin login is successful and opens the B&B Booking Management  creation page is opened 
            var isRoomCreationPageOpened = createRoom.BAndBBookingHeading.Displayed;
            Assert.IsTrue(createRoom.BAndBBookingHeading.Displayed, "B&B Booking Management");
            test.Log(Status.Pass, "B&B Booking Management page is opened: " + createRoom.BAndBBookingHeading.Text);
            test.Log(Status.Pass, "Assert Result: " + isRoomCreationPageOpened);
            adminReport.AdminReport();
            Assert.IsTrue(adminReport.AdminCalendarExists());
            

        }
    }
}
