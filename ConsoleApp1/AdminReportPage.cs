using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RestfulBooker
{
    public class AdminReportPage : BasePage
    {


        [FindsBy(How = How.CssSelector, Using = "#reportLink")]
        public IWebElement Report; 
        [FindsBy(How = How.CssSelector, Using = ".rbc-calendar")]
        public IWebElement Calendar;


        public void AdminReport()
        {
            Report.Click();
        }
        public bool AdminCalendarExists()
        {
            return Calendar.Displayed;
        }

        public AdminReportPage(IWebDriver driver) : base(driver)
        {
        }
    }

}
