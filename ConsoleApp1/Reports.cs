using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
namespace SeleniumNUnitExtentReport.Config
{
    [SetUpFixture]
    public abstract class Reports
    {
        protected AventStack.ExtentReports.ExtentReports extent;
        protected ExtentTest test;
        public IWebDriver _driver;
        [OneTimeSetUp]
        protected void Setup()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "LocalHost");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("UserName", "TestUser");
        }
        [OneTimeTearDown]
        protected void TearDown()
        {
            extent.Flush();
        }
        [SetUp]
        public void BeforeTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
            ? "" : $"{TestContext.CurrentContext.Result.StackTrace}";
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    var time = DateTime.Now;
                    var fileName = $"Screenshot_{time:h_mm_ss}.png";
                    var screenShotPath = Capture(_driver, fileName);
                    test.Log(Status.Fail, "Fail");
                    test.Log(Status.Fail,
                        $"Snapshot below : {test.AddScreenCaptureFromPath($"Screenshots\\{fileName}")}");

                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                case TestStatus.Passed:
                case TestStatus.Warning:
                default:
                    logstatus = Status.Pass;
                    break;
            }
            test.Log(logstatus, $"Test ended with: {logstatus}{stacktrace}");
            extent.Flush();
            _driver.Quit();
        }

        private static string Capture(IWebDriver driver, string screenShotName)
        {
            var ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot();
            var pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            var reportPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory($"{reportPath}Reports\\Screenshots");
            var filepath = $"{pth.Substring(0, pth.LastIndexOf("bin"))}Reports\\Screenshots\\{screenShotName}";
            var localpath = new Uri(filepath).LocalPath;
            screenshot.SaveAsFile(localpath, ScreenshotImageFormat.Png);
            return reportPath;
        }
    }
}