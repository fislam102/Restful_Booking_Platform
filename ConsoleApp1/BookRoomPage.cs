using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RestfulBooker
{
    public class BookRoomPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".navbar-brand.mx-auto")]
        private IWebElement BookingManagement;

        [FindsBy(How = How.Id, Using = "frontPageLink")]
        private IWebElement SelectOnFrontPage;

        [FindsBy(How = How.XPath, Using = "//div[6]//div[1]//div[1]//div[3]//button[1]")]
        private IWebElement SelectBookThisRoom;

        [FindsBy(How = How.CssSelector, Using = "input[name='firstname']")]
        private IWebElement InputFirstName;

        [FindsBy(How = How.CssSelector, Using = "input[name='lastname']")]
        private IWebElement InputLastName;

        [FindsBy(How = How.CssSelector, Using = "input[name='email']")]
        private IWebElement InputEmail;

        [FindsBy(How = How.CssSelector, Using = "input[name='phone']")]
        private IWebElement InputPhone;

        [FindsBy(How = How.CssSelector, Using = "button[class='btn btn-outline-primary float-right book-room']")]
        private IWebElement SelectBookButton;


        public void ClickBookingManagement()
        {
            BookingManagement.Click();
        }
        public void ClickOnFrontPage()
        {
            SelectOnFrontPage.Click();
        }

        public void ClickBookThisRoom()
        {
            SelectBookThisRoom.Click();

        }

        public void EnterFirstName(string FirstName)
        {
            InputFirstName.SendKeys(FirstName);
        }
        public void EnterLastName(string LastName)
        {
            InputLastName.SendKeys(LastName);
        }
        public void EnterEmail(string Email)
        {
            InputEmail.SendKeys(Email);
        }
        public void EnterPhoneNumber(string PhoneNumber)
        {
            InputPhone.SendKeys(PhoneNumber);
        }
        public void ClickBookButton()
        {
            SelectBookButton.Click();
        }

        public BookRoomPage(IWebDriver driver) : base(driver)
        {
        }
    }

}

