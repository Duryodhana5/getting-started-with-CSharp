using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using getting_started_with_CSharp.Drivers;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using AventStack.ExtentReports.MarkupUtils;
using NUnit.Framework.Interfaces;
using getting_started_with_CSharp.Pages.HrmOrangePages;

namespace getting_started_with_CSharp.Utilities
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;
        private static ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            DateTime currentTime = DateTime.Now;
            string filename = "Extent_" + currentTime.ToString("yyyy_MM_dd_HH_mm_ss") + ".html";
            extent = CreateInstance(filename);
        }

        public static ExtentReports CreateInstance(string filename)
        {
            var htmlReport = new ExtentSparkReporter(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).FullName, "reports", filename));
            //var htmlReport = new ExtentSparkReporter(@"C:\\Users\\duryo\\source\\repos\\getting-started-with-CSharp\\Reports\\" + filename);

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
            driver = WebDriverManager.GetDriver();
            string baseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
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
            extent.Flush();
        }
    }
}