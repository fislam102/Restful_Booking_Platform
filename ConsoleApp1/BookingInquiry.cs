using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RestfulBooker
{
    public class BookingInquiry : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#name")]
        private IWebElement InputName;
        [FindsBy(How = How.CssSelector, Using = "#email")]
        private IWebElement InputEmail;
        [FindsBy(How = How.CssSelector, Using = "#phone")]
        private IWebElement InputPhone;
        [FindsBy(How = How.CssSelector, Using = "#subject")]
        private IWebElement InputSubject;
        [FindsBy(How = How.CssSelector, Using = "#description")]
        private IWebElement InputMessage;
        [FindsBy(How = How.CssSelector, Using = "#submitContact")]
        private IWebElement SelectSubmit;

        [FindsBy(How = How.CssSelector, Using = "div[class='col-sm-5'] div h2")]
        public IWebElement MessageConfirmation;

        public void EnterName(string Name)
        {
            InputName.SendKeys(Name);
        }

        public void EnterEmail(string Email)
        {
            InputEmail.SendKeys(Email);
        }

        public void EnterPhoneNumber(string PhoneNumber)
        {
            InputPhone.SendKeys(PhoneNumber);
        }
        public void EnterSubject(string Subject)
        {
            InputSubject.SendKeys(Subject);
        }
        public void EnterMessage(string Message)
        {
            InputMessage.SendKeys(Message);
        }

        public void ClickSubmitButton()
        {
            SelectSubmit.Click();
        }

        public BookingInquiry(IWebDriver driver) : base(driver)
        {
        }
    }
}
