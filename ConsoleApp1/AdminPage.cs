using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RestfulBooker
{
    public class AdminPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='B&B Booking Management']")]
        public IWebElement BAndBBookingHeading;
        [FindsBy(How = How.Id, Using = "roomName")]
        private IWebElement EnterRoomNumber;
        [FindsBy(How = How.Id, Using = "type")]
        private IWebElement selectRoomType;
        [FindsBy(How = How.Id, Using = "accessible")]
        private IWebElement selectAccessibility;
        [FindsBy(How = How.Id, Using = "roomPrice")]
        private IWebElement inputRoomPrice;
        [FindsBy(How = How.Id, Using = "wifiCheckbox")]
        private IWebElement wifiCheckbox;
        [FindsBy(How = How.Id, Using = "refreshCheckbox")]
        private IWebElement refreshCheckbox;
        [FindsBy(How = How.Id, Using = "tvCheckbox")]
        private IWebElement tvCheckbox;
        [FindsBy(How = How.Id, Using = "safeCheckbox")]
        private IWebElement safeCheckbox;
        [FindsBy(How = How.Id, Using = "radioCheckbox")]
        private IWebElement radioCheckbox;
        [FindsBy(How = How.Id, Using = "viewsCheckbox")]
        private IWebElement viewsCheckbox;
        [FindsBy(How = How.Id, Using = "createRoom")]
        private IWebElement createRoom;
        [FindsBy(How = How.CssSelector, Using = ".fa.fa-inbox")]
        private IWebElement Inbox;
        [FindsBy(How = How.CssSelector, Using = "div[id='message1'] div[class='col-sm-2'] p")]
        public IWebElement Message;
        [FindsBy(How = How.CssSelector, Using = ".btn.btn-outline-primary")]
        private IWebElement CloseButton;


        public void InputRoomNumber(string RoomNumber)
        {
            
            EnterRoomNumber.SendKeys(RoomNumber);
        }

        public void SelectRoomType(string InputRoomType)
        {
            
            selectRoomType.SendKeys(InputRoomType);
        }

        public void SelectAccessibility(string Accessibility)
        {
            selectAccessibility.SendKeys(Accessibility);
        }

        public void EnterRoomPrice(string RoomPrice)
        {
           
            inputRoomPrice.SendKeys(RoomPrice);
        }

        public void SelectWifi()
        {
            wifiCheckbox.Click();
        }

        public void SelectRefreshments()
        {
            refreshCheckbox.Click();
        }

        public void SelectTv()
        {
            tvCheckbox.Click();
        }

        public void SelectSafe()
        {
            safeCheckbox.Click();
        }

        public void SelectRadio()
        {
            radioCheckbox.Click();
        }

        public void SelectViews()
        {
            viewsCheckbox.Click();
        }

        public void ClickOnCreateRoomButton()
        {
            createRoom.Click();
        }

        public void ClickInbox()
        {
            Inbox.Click();
        }

        public void ReadMessage()
        {
            Message.Click();
        }
        public void ClickCloseButton()
        {
            CloseButton.Click();
        }

        public AdminPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
