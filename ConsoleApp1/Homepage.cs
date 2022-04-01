using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RestfulBooker
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "button[class='btn btn-primary']")]
        private IWebElement LetMeHackButton; 

        [FindsBy(How = How.CssSelector, Using = "a[href='/#/admin']")]

        private IWebElement AdminLinkButton;

        public void GoToHomePage()
        {
            PageFactory.InitElements(driver, this);
           
            driver.Navigate().GoToUrl(AdminPageUrl);

        }

        public void ClickHackButton()
        {
            LetMeHackButton.Click();
        }

        public void ClickAdminLinkButton()
        {
            AdminLinkButton.Click();
        }

        public HomePage(IWebDriver driver) : base(driver)
        {
        }
    }


}