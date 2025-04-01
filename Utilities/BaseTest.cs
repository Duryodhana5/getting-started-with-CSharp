using System;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using getting_started_with_CSharp.Drivers;
using getting_started_with_CSharp.Pages.HrmOrangePages;

namespace getting_started_with_CSharp.Utilities
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;
        private static ExtentReports extent;
        protected ExtentTest test;
        protected string browserType;

        // Constructor to accept the browser type
        public BaseTest(string browser)
        {
            this.browserType = browser;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            DateTime currentTime = DateTime.Now;
            string filename = "Extent_" + currentTime.ToString("yyyy_MM_dd_HH_mm_ss") + ".html";
            extent = CreateInstance(filename);

            //Initialize the driver only once per browser type
            driver = WebDriverManager.GetDriver(browserType);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            Thread.Sleep(2000);
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
        }

        public static ExtentReports CreateInstance(string filename)
        {
            var htmlReport = new ExtentSparkReporter(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).FullName, "reports", filename));
            htmlReport.Config.Theme = Theme.Standard;
            htmlReport.Config.DocumentTitle = "Basava Duryodhana";
            htmlReport.Config.ReportName = "Automation Testing";
            htmlReport.Config.Encoding = "UTF-8";

            extent = new ExtentReports();
            extent.AttachReporter(htmlReport);
            extent.AddSystemInfo("Automation Tester", "Basava Duryodhana");
            return extent;
        }

        [SetUp]
        public void SetUp()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void AfterTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus == TestStatus.Passed)
            {
                test.Pass("Pass: " + TestContext.CurrentContext.Result.Message);
                IMarkup markup = MarkupHelper.CreateLabel("PASS", ExtentColor.Orange);
                test.Pass(markup);
            }
            else if (testStatus == TestStatus.Failed)
            {
                test.Fail("Fail: " + TestContext.CurrentContext.Result.Message);
                IMarkup markup = MarkupHelper.CreateLabel("FAIL", ExtentColor.Red);
                test.Fail(markup);
            }
            else if (testStatus == TestStatus.Skipped)
            {
                test.Skip("Skip: " + TestContext.CurrentContext.Result.Message);
                IMarkup markup = MarkupHelper.CreateLabel("SKIP", ExtentColor.Brown);
                test.Skip(markup);
            }
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            // Quit all drivers once all tests are completed for the browser type
            //WebDriverManager.QuitAllDrivers();
            driver.Dispose();
            extent.Flush();
        }
    }
}
