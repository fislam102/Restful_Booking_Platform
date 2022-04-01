using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RestfulBooker
{
    public class LoginPage : BasePage
    {

        [FindsBy(How = How.CssSelector, Using = "h2[data-testid='login-header']")]
        public IWebElement Heading { get; set; }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement _userName;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _password;

        [FindsBy(How = How.CssSelector, Using = "#doLogin")]
        private IWebElement _loginButton;

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Logout']")]
        private IWebElement _logout;

        public void EnterUsername(string username)
        {
            _userName.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _password.SendKeys(password);
        }

        public void ClickOnLoginButton()
        {
            _loginButton.Click();
        }

        public void SelectLogOut()
        {
            _logout.Click();
        }


        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
    }
}