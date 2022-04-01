using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RestfulBooker
{
    public class BasePage
    {
        public IWebDriver driver;

        public BasePage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public static string AdminPageUrl = "https://automationintesting.online/#/";
    }
    
}
